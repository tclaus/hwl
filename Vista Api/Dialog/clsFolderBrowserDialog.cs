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
using System.ComponentModel;
using System.IO;
using Vista_Api.Dialog.Native;

namespace Vista_Api
{
    /// <summary>
    /// Prompts the user to select a folder.
    /// </summary>
    /// <remarks>
    /// This class will use the Vista style Select Folder dialog if possible, or the regular FolderBrowserDialog
    /// if it is not. Note that the Vista style dialog is very different, so using this class without testing
    /// in both Vista and older Windows versions is not recommended.
    /// </remarks>
    [System.Drawing.ToolboxBitmap(typeof(System.Windows.Forms.FolderBrowserDialog), "FolderBrowserDialog.bmp"), DefaultEvent("HelpRequest"), Designer("System.Windows.Forms.Design.FolderBrowserDialogDesigner, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), DefaultProperty("SelectedPath"), Description("Prompts the user to select a folder.")]
    public class FolderBrowserDialog : CommonDialog
    {
        private System.Windows.Forms.FolderBrowserDialog _downlevelDialog;
        private string _description;
        private bool _useDescriptionForTitle;
        private string _selectedPath;
        private System.Environment.SpecialFolder _rootFolder;

        /// <summary>
        /// Occurs when the user clicks the Help button on the dialog box.
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler HelpRequest
        {
            add
            {
                base.HelpRequest += value;
            }
            remove
            {
                base.HelpRequest -= value;
            }
        }

        /// <summary>
        /// Creates a new instance of the <see cref="FolderBrowserDialog" /> class.
        /// </summary>
        public FolderBrowserDialog()
            : this(false)
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="FolderBrowserDialog" /> class.
        /// </summary>
        /// <param name="forceDownlevel">true to force the use of the old style folder browser dialog, even when the Vista
        /// style dialog is supported; otherwise, false.</param>
        public FolderBrowserDialog(bool forceDownlevel)
        {
            if( forceDownlevel || !IsVistaFolderDialogSupported )
                _downlevelDialog = new System.Windows.Forms.FolderBrowserDialog();
            else
                Reset();
        }

        #region Public Properties

        /// <summary>
        /// Gets a value that indicates whether the current OS supports Vista-style common file dialogs.
        /// </summary>
        /// <value>
        /// Returns true on Windows Vista or newer operating systems; otherwise, false.
        /// </value>
        [Browsable(false)]
        public static bool IsVistaFolderDialogSupported
        {
            get
            {
                return Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major >= 6;
            }
        }

        /// <summary>
        /// Gets or sets the descriptive text displayed above the tree view control in the dialog box, or below the list view control
        /// in the Vista style dialog.
        /// </summary>
        /// <value>
        /// The description to display. The default is an empty string ("").
        /// </value>
        [Category("Folder Browsing"), DefaultValue(""), Localizable(true), Browsable(true), Description("The descriptive text displayed above the tree view control in the dialog box, or below the list view control in the Vista style dialog.")]
        public string Description
        {
            get
            {
                if( _downlevelDialog != null )
                    return _downlevelDialog.Description;
                return _description;
            }
            set
            {
                if( _downlevelDialog != null )
                    _downlevelDialog.Description = value;
                else
                    _description = value ?? String.Empty;
            }
        }

        /// <summary>
        /// Gets or sets the root folder where the browsing starts from. This property has no effect if the Vista style
        /// dialog is used.
        /// </summary>
        /// <value>
        /// One of the <see cref="System.Environment.SpecialFolder" /> values. The default is Desktop.
        /// </value>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">The value assigned is not one of the <see cref="System.Environment.SpecialFolder" /> values.</exception>
        [Localizable(false), Description("The root folder where the browsing starts from. This property has no effect if the Vista style dialog is used."), Category("Folder Browsing"), Browsable(true), DefaultValue(typeof(System.Environment.SpecialFolder), "Desktop")]
        public System.Environment.SpecialFolder RootFolder
        {
            get
            {
                if( _downlevelDialog != null )
                    return _downlevelDialog.RootFolder;
                return _rootFolder;
            }
            set
            {
                if( _downlevelDialog != null )
                    _downlevelDialog.RootFolder = value;
                else
                    _rootFolder = value;
            }
        }
	
        /// <summary>
        /// Gets or sets the path selected by the user.
        /// </summary>
        /// <value>
        /// The path of the folder first selected in the dialog box or the last folder selected by the user. The default is an empty string ("").
        /// </value>
        [Browsable(true), Editor("System.Windows.Forms.Design.SelectedPathEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor)), Description("The path selected by the user."), DefaultValue(""), Localizable(true), Category("Folder Browsing")]
        public string SelectedPath
        {
            get
            {
                if( _downlevelDialog != null )
                    return _downlevelDialog.SelectedPath;
                return _selectedPath;
            }
            set
            {
                if( _downlevelDialog != null )
                    _downlevelDialog.SelectedPath = value;
                else
                    _selectedPath = value ?? string.Empty;
            }
        }

        private bool _showNewFolderButton;

        /// <summary>
        /// Gets or sets a value indicating whether the New Folder button appears in the folder browser dialog box. This
        /// property has no effect if the Vista style dialog is used; in that case, the New Folder button is always shown.
        /// </summary>
        /// <value>
        /// true if the New Folder button is shown in the dialog box; otherwise, false. The default is true.
        /// </value>
        [Browsable(true), Localizable(false), Description("A value indicating whether the New Folder button appears in the folder browser dialog box. This property has no effect if the Vista style dialog is used; in that case, the New Folder button is always shown."), DefaultValue(true), Category("Folder Browsing")]
        public bool ShowNewFolderButton
        {
            get
            {
                if( _downlevelDialog != null )
                    return _downlevelDialog.ShowNewFolderButton;
                return _showNewFolderButton;
            }
            set
            {
                if( _downlevelDialog != null )
                    _downlevelDialog.ShowNewFolderButton = value;
                else
                    _showNewFolderButton = value;
            }
        }
	

        /// <summary>
        /// Gets or sets a value that indicates whether to use the value of the <see cref="Description" /> property
        /// as the dialog title for Vista style dialogs. This property has no effect on old style dialogs.
        /// </summary>
        /// <value>true to indicate that the value of the <see cref="Description" /> property is used as dialog title; false
        /// to indicate the value is added as additional text to the dialog. The default is false.</value>
        [Category("Folder Browsing"), DefaultValue(false), Description("A value that indicates whether to use the value of the Description property as the dialog title for Vista style dialogs. This property has no effect on old style dialogs.")]
        public bool UseDescriptionForTitle
        {
            get { return _useDescriptionForTitle; }
            set { _useDescriptionForTitle = value; }
        }	

        #endregion

        #region Public Methods

        /// <summary>
        /// Resets all properties to their default values.
        /// </summary>
        public override void Reset()
        {
            _description = string.Empty;
            _useDescriptionForTitle = false;
            _selectedPath = string.Empty;
            _rootFolder = Environment.SpecialFolder.Desktop;
            _showNewFolderButton = true;
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
            if( _downlevelDialog != null )
                return _downlevelDialog.ShowDialog(hwndOwner == IntPtr.Zero ? null : new WindowHandleWrapper(hwndOwner)) == DialogResult.OK;

            IFileDialog dialog = null;
            try
            {
                dialog = new NativeFileOpenDialog();
                SetDialogProperties(dialog);
                int result = dialog.Show(hwndOwner);
                if( result < 0 )
                {
                    if( (uint)result == NativeMethods.ERROR_CANCELLED )
                        return false;
                    else
                        throw System.Runtime.InteropServices.Marshal.GetExceptionForHR(result);
                } 
                GetResult(dialog);
                return true;
            }
            finally
            {
                if( dialog != null )
                    System.Runtime.InteropServices.Marshal.FinalReleaseComObject(dialog);
            }
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="FileDialog" /> and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            try
            {
                if( disposing && _downlevelDialog != null )
                    _downlevelDialog.Dispose();
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        #endregion

        #region Private Methods

        private void SetDialogProperties(IFileDialog dialog)
        {
            // Description
            if( !string.IsNullOrEmpty(_description) )
            {
                if( _useDescriptionForTitle )
                {
                    dialog.SetTitle(_description);
                }
                else
                {
                    IFileDialogCustomize customize = (IFileDialogCustomize)dialog;
                    customize.AddText(0, _description);
                }
            }

            dialog.SetOptions(NativeMethods.FOS.FOS_PICKFOLDERS | NativeMethods.FOS.FOS_FORCEFILESYSTEM | NativeMethods.FOS.FOS_FILEMUSTEXIST);

            if( !string.IsNullOrEmpty(_selectedPath) )
            {
                string parent = Path.GetDirectoryName(_selectedPath);
                if( parent == null || !Directory.Exists(parent) )
                {
                    dialog.SetFileName(_selectedPath);
                }
                else
                {
                    string folder = Path.GetFileName(_selectedPath);
                    dialog.SetFolder(NativeMethods.CreateItemFromParsingName(parent));
                    dialog.SetFileName(folder);
                }
            }
        }

        private void GetResult(IFileDialog dialog)
        {
            IShellItem item;
            dialog.GetResult(out item);
            item.GetDisplayName(NativeMethods.SIGDN.SIGDN_FILESYSPATH, out _selectedPath);
        }

        #endregion
    }
}
