/*
_____________________________________
� Pedro Miguel C. Cardoso 2007.
All rights reserved.
http://pmcchp.com/

Redistribution and use in source and binary forms, with or without 
modification, are permitted provided that the following conditions are met:

1) Redistributions of source code must retain the above copyright notice, 
   this list of conditions and the following disclaimer. 
2) Redistributions in binary form must reproduce the above copyright notice,
   this list of conditions and the following disclaimer in the documentation
   and/or other materials provided with the distribution. 
3) Neither the name of the ORGANIZATION nor the names of its contributors
   may be used to endorse or promote products derived from this software
   without specific prior written permission. 

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE
LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF
THE POSSIBILITY OF SUCH DAMAGE.
*/
// Copyright (c) Sven Groot (Ookii.org) 2006

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.ComponentModel;
using Vista_Api.Dialog.Native;

namespace Vista_Api
{
    /// <summary>
    /// Displays a dialog box from which the user can select a file.
    /// </summary>
    /// <remarks>
    /// This class will use the Vista style file dialog if possible, and automatically fall back to the old-style 
    /// dialog on versions of Windows older than Vista.
    /// </remarks>
    [DefaultEvent("FileOk"), DefaultProperty("FileName")]
    public abstract class FileDialog : CommonDialog
    {
        internal const int HelpButtonId = 0x4001;

        private System.Windows.Forms.FileDialog _downlevelDialog;
        private NativeMethods.FOS _options;
        private string _filter;
        private int _filterIndex ;
        private string[] _fileNames;
        private string _defaultExt;
        private bool _addExtension;
        private string _initialDirectory;
        private bool _showHelp;
        private string _title;
        private bool _supportMultiDottedExtensions;
        private IntPtr _hwndOwner;
        private static readonly object EventFileOk = new object();

        /// <summary>
        /// Occurs when the user clicks on the Open or Save button on a file dialog box.
        /// </summary>
        public event System.ComponentModel.CancelEventHandler FileOk
        {
            add
            {
                base.Events.AddHandler(EventFileOk, value);
            }
            remove
            {
                base.Events.RemoveHandler(EventFileOk, value);
            }
        }

        /// <summary>
        /// Creates a new insatnce of <see cref="FileDialog" /> class.
        /// </summary>
        protected FileDialog()
        {
            Reset();
        }

        #region Public Properties

       

        /// <summary>
        /// Gets or sets a value indicating whether the dialog box automatically adds an extension to a file name 
        /// if the user omits the extension.
        /// </summary>
        /// <value>
        /// true if the dialog box adds an extension to a file name if the user omits the extension; otherwise, false. 
        /// The default value is true.
        /// </value>
        [Description("A value indicating whether the dialog box automatically adds an extension to a file name if the user omits the extension."), Category("Behavior"), DefaultValue(true)]
        public bool AddExtension
        {
            get
            {
                if( DownlevelDialog != null )
                    return DownlevelDialog.AddExtension;
                return _addExtension;
            }
            set
            {
                if( DownlevelDialog != null )
                    DownlevelDialog.AddExtension = value;
                else
                    _addExtension = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the dialog box displays a warning if the user specifies a file name that does not exist.
        /// </summary>
        /// <value>
        /// true if the dialog box displays a warning if the user specifies a file name that does not exist; otherwise, false. The default value is false.
        /// </value>
        [Description("A value indicating whether the dialog box displays a warning if the user specifies a file name that does not exist."), Category("Behavior"), DefaultValue(false)]
        public virtual bool CheckFileExists
        {
            get
            {
                if( DownlevelDialog != null )
                    return DownlevelDialog.CheckFileExists;
                return GetOption(NativeMethods.FOS.FOS_FILEMUSTEXIST);
            }
            set
            {
                if( DownlevelDialog != null )
                    DownlevelDialog.CheckFileExists = value;
                else
                    SetOption(NativeMethods.FOS.FOS_FILEMUSTEXIST, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the dialog box displays a warning if the user specifies a path that does not exist.
        /// </summary>
        /// <value>
        /// true if the dialog box displays a warning when the user specifies a path that does not exist; otherwise, false. 
        /// The default value is true.
        /// </value>
        [Description("A value indicating whether the dialog box displays a warning if the user specifies a path that does not exist."), DefaultValue(true), Category("Behavior")]
        public bool CheckPathExists
        {
            get
            {
                if( DownlevelDialog != null )
                    return DownlevelDialog.CheckPathExists;
                return GetOption(NativeMethods.FOS.FOS_PATHMUSTEXIST);
            }
            set
            {
                if( DownlevelDialog != null )
                    DownlevelDialog.CheckPathExists = value;
                else
                    SetOption(NativeMethods.FOS.FOS_PATHMUSTEXIST, value);
            }
        }
	
        /// <summary>
        /// Gets or sets the default file name extension.
        /// </summary>
        /// <value>
        /// The default file name extension. The returned string does not include the period. The default value is an empty string ("").
        /// </value>
        [Category("Behavior"), DefaultValue(""), Description("The default file name extension.")]
        public string DefaultExt
        {
            get
            {
                if( DownlevelDialog != null )
                    return DownlevelDialog.DefaultExt;
                if( _defaultExt != null )
                    return _defaultExt;
                return string.Empty;
            }
            set
            {
                if( DownlevelDialog != null )
                    DownlevelDialog.DefaultExt = value;
                else
                {
                    if( value != null )
                    {
                        if( value.StartsWith(".") )
                            value = value.Substring(1);
                        else if( value.Length == 0 )
                            value = null;
                    }

                    _defaultExt = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the dialog box returns the location of the file referenced by the shortcut 
        /// or whether it returns the location of the shortcut (.lnk).
        /// </summary>
        /// <value>
        /// true if the dialog box returns the location of the file referenced by the shortcut; otherwise, false.
        /// The default value is true.
        /// </value>
        [Category("Behavior"), Description("A value indicating whether the dialog box returns the location of the file referenced by the shortcut or whether it returns the location of the shortcut (.lnk)."), DefaultValue(true)]
        public bool DereferenceLinks
        {
            get
            {
                if( DownlevelDialog != null )
                    return DownlevelDialog.DereferenceLinks;
                return !GetOption(NativeMethods.FOS.FOS_NODEREFERENCELINKS);
            }
            set
            {
                if( DownlevelDialog != null )
                    DownlevelDialog.DereferenceLinks = value;
                else
                    SetOption(NativeMethods.FOS.FOS_NODEREFERENCELINKS, !value);
            }
        }
	

        /// <summary>
        /// Gets or sets a string containing the file name selected in the file dialog box.
        /// </summary>
        /// <value>
        /// The file name selected in the file dialog box. The default value is an empty string ("").
        /// </value>
        [DefaultValue(""), Category("Data"), Description("A string containing the file name selected in the file dialog box.")]
        public string FileName
        {
            get
            {
                if( DownlevelDialog != null )
                    return DownlevelDialog.FileName;

                if( _fileNames == null || _fileNames.Length == 0 || string.IsNullOrEmpty(_fileNames[0]) )
                    return string.Empty;
                else
                    return _fileNames[0];
            }
            set
            {
                if( DownlevelDialog != null )
                    DownlevelDialog.FileName = value;
                _fileNames = new string[1];
                _fileNames[0] = value;
            }
        }

        /// <summary>
        /// Gets the file names of all selected files in the dialog box.
        /// </summary>
        /// <value>
        /// An array of type String, containing the file names of all selected files in the dialog box.
        /// </value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays")] // suppressed because it matches FileDialog
        [Description("The file names of all selected files in the dialog box."), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string[] FileNames
        {
            get
            {
                if( DownlevelDialog != null )
                    return DownlevelDialog.FileNames;
                return FileNamesInternal;
            }
        }

        /// <summary>
        /// Gets or sets the current file name filter string, which determines the choices that appear in the 
        /// "Save as file type" or "Files of type" box in the dialog box.
        /// </summary>
        /// <value>
        /// The file filtering options available in the dialog box.
        /// </value>
        /// <exception cref="System.ArgumentException">Filter format is invalid.</exception>
        [Description("The current file name filter string, which determines the choices that appear in the \"Save as file type\" or \"Files of type\" box in the dialog box."), Category("Behavior"), Localizable(true), DefaultValue("")]
        public string Filter
        {
            get
            {
                if( DownlevelDialog != null )
                    return DownlevelDialog.Filter;
                return _filter;
            }
            set
            {
                if( DownlevelDialog != null )
                    DownlevelDialog.Filter = value;
                else
                {
                    if( value != _filter )
                    {
                        if( !string.IsNullOrEmpty(value) )
                        {
                            string[] filterElements = value.Split(new char[] { '|' });
                            if( filterElements == null || filterElements.Length % 2 != 0 )
                                throw new ArgumentException("Invalid filter string");

                        }
                        else
                            value = null;
                        _filter = value;
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the index of the filter currently selected in the file dialog box.
        /// </summary>
        /// <value>
        /// A value containing the index of the filter currently selected in the file dialog box. The default value is 1.
        /// </value>
        [Description("The index of the filter currently selected in the file dialog box."), Category("Behavior"), DefaultValue(1)]
        public int FilterIndex
        {
            get
            {
                if( DownlevelDialog != null )
                    return DownlevelDialog.FilterIndex;
                return _filterIndex;
            }
            set
            {
                if( DownlevelDialog != null )
                    DownlevelDialog.FilterIndex = value;
                else
                    _filterIndex = value;
            }
        }

        /// <summary>
        /// Gets or sets the initial directory displayed by the file dialog box.
        /// </summary>
        /// <value>
        /// The initial directory displayed by the file dialog box. The default is an empty string ("").
        /// </value>
        [Description("The initial directory displayed by the file dialog box."), DefaultValue(""), Category("Data")]
        public string InitialDirectory
        {
            get
            {
                if( DownlevelDialog != null )
                    return DownlevelDialog.InitialDirectory;

                if( _initialDirectory != null )
                    return _initialDirectory;
                else
                    return string.Empty;
            }
            set
            {
                if( DownlevelDialog != null )
                    DownlevelDialog.InitialDirectory = value;
                else
                    _initialDirectory = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the dialog box restores the current directory before closing.
        /// </summary>
        /// <value>
        /// true if the dialog box restores the current directory to its original value if the user changed the 
        /// directory while searching for files; otherwise, false. The default value is false.
        /// </value>
        [DefaultValue(false), Description("A value indicating whether the dialog box restores the current directory before closing."), Category("Behavior")]
        public bool RestoreDirectory
        {
            get
            {
                if( DownlevelDialog != null )
                    return DownlevelDialog.RestoreDirectory;
                return GetOption(NativeMethods.FOS.FOS_NOCHANGEDIR);
            }
            set
            {
                if( DownlevelDialog != null )
                    DownlevelDialog.RestoreDirectory = value;
                else
                    SetOption(NativeMethods.FOS.FOS_NOCHANGEDIR, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the Help button is displayed in the file dialog box.
        /// </summary>
        /// <value>
        /// true if the dialog box includes a help button; otherwise, false. The default value is false.
        /// </value>
        [Description("A value indicating whether the Help button is displayed in the file dialog box."), DefaultValue(false), Category("Behavior")]
        public bool ShowHelp
        {
            get
            {
                if( DownlevelDialog != null )
                    return DownlevelDialog.ShowHelp;
                return _showHelp;
            }
            set
            {
                if( DownlevelDialog != null )
                    DownlevelDialog.ShowHelp = value;
                else
                    _showHelp = value;
            }
        }

        /// <summary>
        /// Gets or sets the file dialog box title.
        /// </summary>
        /// <value>
        /// The file dialog box title. The default value is an empty string ("").
        /// </value>
        [Description("The file dialog box title."), Category("Appearance"), DefaultValue(""), Localizable(true)]
        public string Title
        {
            get
            {
                if( DownlevelDialog != null )
                    return DownlevelDialog.Title;
                if( _title != null )
                    return _title;
                else
                    return string.Empty;
            }
            set
            {
                if( DownlevelDialog != null )
                    DownlevelDialog.Title = value;
                else
                    _title = value;
            }
        }

        /// <summary>
        /// Gets or sets whether the dialog box supports displaying and saving files that have multiple file name extensions.
        /// </summary>
        /// <value>
        /// true if the dialog box supports multiple file name extensions; otherwise, false. The default is false.
        /// </value>
        [Description("Indicates whether the dialog box supports displaying and saving files that have multiple file name extensions."), Category("Behavior"), DefaultValue(false)]
        public bool SupportMultiDottedExtensions
        {
            get
            {
                if( DownlevelDialog != null )
                    return DownlevelDialog.SupportMultiDottedExtensions;
                return _supportMultiDottedExtensions;
            }
            set
            {
                if( DownlevelDialog != null )
                    DownlevelDialog.SupportMultiDottedExtensions = value;
                else
                    _supportMultiDottedExtensions = value;
            }
        }
	

        /// <summary>
        /// Gets or sets a value indicating whether the dialog box accepts only valid Win32 file names.
        /// </summary>
        /// <value>
        /// true if the dialog box accepts only valid Win32 file names; otherwise, false. The default value is true.
        /// </value>
        [DefaultValue(true), Category("Behavior"), Description("A value indicating whether the dialog box accepts only valid Win32 file names.")]
        public bool ValidateNames
        {
            get
            {
                if( DownlevelDialog != null )
                    return DownlevelDialog.ValidateNames;
                return !GetOption(NativeMethods.FOS.FOS_NOVALIDATE);
            }
            set
            {
                if( DownlevelDialog != null )
                    DownlevelDialog.ValidateNames = value;
                else
                    SetOption(NativeMethods.FOS.FOS_NOVALIDATE, !value);
            }
        }
	

        #endregion

        #region Protected Properties

        /// <summary>
        /// Provides the downlevel file dialog which is to be used if the Vista-style
        /// dialog is not supported.
        /// </summary>
        [Browsable(false)]
        protected System.Windows.Forms.FileDialog DownlevelDialog
        {
            get
            {
                return _downlevelDialog;
            }
            set
            {
                _downlevelDialog = value;
                if( value != null )
                {
                    value.HelpRequest += new EventHandler(DownlevelDialog_HelpRequest);
                    value.FileOk += new System.ComponentModel.CancelEventHandler(DownlevelDialog_FileOk);
                }
            }
        }

        #endregion

        #region Internal Properties

        internal string[] FileNamesInternal
        {
            private get
            {
                if( _fileNames == null )
                {
                    return new string[0];
                }
                return (string[])_fileNames.Clone();
            }
            set
            {
                _fileNames = value;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Resets all properties to their default values.
        /// </summary>
        public override void Reset()
        {
            if( DownlevelDialog != null )
                DownlevelDialog.Reset();
            else
            {
                _fileNames = null;
                _filter = null;
                _filterIndex = 1;
                _addExtension = true;
                _defaultExt = null;
                _options = 0;
                _showHelp = false;
                _title = null;
                _supportMultiDottedExtensions = false;
                CheckPathExists = true;
            }
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Specifies a common dialog box.
        /// </summary>
        /// <param name="hwndOwner">A value that represents the window handle of the owner window for the common dialog box.</param>
        /// <returns>true if the file could be opened; otherwise, false.</returns>
        protected override bool RunDialog(IntPtr hwndOwner)
        {
            if( DownlevelDialog != null )
                return DownlevelDialog.ShowDialog(hwndOwner == IntPtr.Zero ? null : new WindowHandleWrapper(hwndOwner)) == DialogResult.OK;
            else
                return RunFileDialog(hwndOwner);
        }

        internal void SetOption(NativeMethods.FOS option, bool value)
        {
            if( value )
                _options |= option;
            else
                _options &= ~option;
        }

        internal bool GetOption(NativeMethods.FOS option)
        {
            return (_options & option) != 0;
        }

        internal virtual void GetResult(IFileDialog dialog)
        {
            if( !GetOption(NativeMethods.FOS.FOS_ALLOWMULTISELECT) )
            {
                _fileNames = new string[1];
                IShellItem result;
                dialog.GetResult(out result);
                result.GetDisplayName(NativeMethods.SIGDN.SIGDN_FILESYSPATH, out _fileNames[0]);
            }
        }

        /// <summary>
        /// Raises the <see cref="FileOk" /> event.
        /// </summary>
        /// <param name="e">A <see cref="System.ComponentModel.CancelEventArgs" /> that contains the event data.</param>
        protected virtual void OnFileOk(System.ComponentModel.CancelEventArgs e)
        {
            System.ComponentModel.CancelEventHandler handler = (System.ComponentModel.CancelEventHandler)base.Events[EventFileOk];
            if( handler != null )
                handler(this, e);
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="FileDialog" /> and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            try
            {
                if( disposing && DownlevelDialog != null )
                    DownlevelDialog.Dispose();
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        #endregion

        #region Internal Methods

        internal bool PromptUser(string text, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            string caption = string.IsNullOrEmpty(_title) ? 
                (this is OpenFileDialog ? ComDlgResources.LoadString(ComDlgResources.ComDlgResourceId.Open) : ComDlgResources.LoadString(ComDlgResources.ComDlgResourceId.ConfirmSaveAs)) : 
                _title;
            IWin32Window owner = _hwndOwner == IntPtr.Zero ? null : new WindowHandleWrapper(_hwndOwner);
            MessageBoxOptions options = 0;
            if( System.Threading.Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft )
                options |= MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading;
            return MessageBox.Show(owner, text, caption, buttons, icon, MessageBoxDefaultButton.Button1, options) == DialogResult.Yes;
        }
        
        internal virtual void SetDialogProperties(IFileDialog dialog)
        {
            uint cookie;
            dialog.Advise(new VistaFileDialogEvents(this), out cookie);

            // Set the default file name
            if( !(_fileNames == null || _fileNames.Length == 0 || string.IsNullOrEmpty(_fileNames[0])) )
            {
                string parent = Path.GetDirectoryName(_fileNames[0]);
                if( parent == null || !Directory.Exists(parent) )
                {
                    dialog.SetFileName(_fileNames[0]);
                }
                else
                {
                    string folder = Path.GetFileName(_fileNames[0]);
                    dialog.SetFolder(NativeMethods.CreateItemFromParsingName(parent));
                    dialog.SetFileName(folder);
                }
            }

            // Set the filter
            if( !string.IsNullOrEmpty(_filter) )
            {
                string[] filterElements = _filter.Split(new char[] { '|' });
                NativeMethods.COMDLG_FILTERSPEC[] filter = new NativeMethods.COMDLG_FILTERSPEC[filterElements.Length / 2];
                for( int x = 0; x < filterElements.Length; x += 2 )
                {
                    filter[x / 2].pszName = filterElements[x];
                    filter[x / 2].pszSpec = filterElements[x + 1];
                }
                dialog.SetFileTypes((uint)filter.Length, filter);

                if( _filterIndex > 0 && _filterIndex <= filter.Length )
                    dialog.SetFileTypeIndex((uint)_filterIndex);
            }

            // Default extension
            if( _addExtension && !string.IsNullOrEmpty(_defaultExt) )
            {
                dialog.SetDefaultExtension(_defaultExt);
            }

            // Initial directory
            if( !string.IsNullOrEmpty(_initialDirectory) )
            {
                IShellItem item = NativeMethods.CreateItemFromParsingName(_initialDirectory);
                dialog.SetDefaultFolder(item);
            }

            // ShowHelp
            if( _showHelp )
            {
                IFileDialogCustomize customize = (IFileDialogCustomize)dialog;
                customize.AddPushButton(HelpButtonId, "&Help");
            }

            if( !string.IsNullOrEmpty(_title) )
            {
                dialog.SetTitle(_title);
            }

            dialog.SetOptions((_options | NativeMethods.FOS.FOS_FORCEFILESYSTEM));
        }

        internal abstract IFileDialog CreateFileDialog();

        internal void DoHelpRequest()
        {
            OnHelpRequest(new HelpEventArgs(Cursor.Position));
        }

        internal bool DoFileOk(IFileDialog dialog)
        {
            GetResult(dialog);

            System.ComponentModel.CancelEventArgs e = new System.ComponentModel.CancelEventArgs();
            OnFileOk(e);
            return !e.Cancel;
        }

        #endregion

        #region Private Methods

        private bool RunFileDialog(IntPtr hwndOwner)
        {
            _hwndOwner = hwndOwner;
            IFileDialog dialog = null;
            try
            {
                dialog = CreateFileDialog();
                SetDialogProperties(dialog);
                int result = dialog.Show(hwndOwner);
                if( result < 0 )
                {
                    if( (uint)result == NativeMethods.ERROR_CANCELLED )
                        return false;
                    else
                        throw System.Runtime.InteropServices.Marshal.GetExceptionForHR(result);
                }
                return true;
            }
            finally
            {
                _hwndOwner = IntPtr.Zero;
                if( dialog != null )
                    System.Runtime.InteropServices.Marshal.FinalReleaseComObject(dialog);
            }
        }
        
        private void DownlevelDialog_HelpRequest(object sender, EventArgs e)
        {
            OnHelpRequest(e);
        }

        private void DownlevelDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            OnFileOk(e);
        }

        #endregion
    }
}
