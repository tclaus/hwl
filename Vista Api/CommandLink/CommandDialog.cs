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

using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System;
namespace Vista_Api
{
    /// <summary>
    /// Provides a Vista-Style command Dialog
    /// </summary>
    public partial class CommandDialog
    {

        #region " Declarations "

        private List<CommandLink> mCommandLinks;
        
        private CommandLink mSelectedCommandLink;
        /// <summary>
        /// Keeps the ordinal number of the selected Command Link
        /// </summary>
        private int mSelectedCommandID;
        private bool mShowCancelButton;

        #endregion

        #region " Constructors "
        
        /// <summary>
        /// Creates a new CommandDialog
        /// </summary>
        public CommandDialog()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
            mCommandLinks = new List<CommandLink>();
            mSelectedCommandLink = null;
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            mShowCancelButton = true;
            this.CancelButton = btnCancel;
        }
        /// <summary>
        /// Gives a List of CommandLinks
        /// </summary>
        /// <param name="commandLinks"></param>
        public CommandDialog(List<CommandLink> commandLinks)
            : this()
        {
            this.CommandLinks = commandLinks;
        }

        #endregion

        #region " Properties "
        /// <summary>
        /// Der Text erscheint als �berschrift innerhalb er Abfrage
        /// </summary>
        public string Title
        {
            get
            {
                return lblTitle.Text;
            }
            set
            {
                lblTitle.Text = value;
            }
        }
        
        /// <summary>
        /// Ruft den Text in der Kopfzeile des Controls ab oder legt diesen fest
        /// </summary>
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }
        /// <summary>
        /// Der text erscheint als l�ngerer Beschreibender Text unter der �berschrift
        /// </summary>
        public string Description
        {
            get
            {
                return lblDescription.Text;
            }
            set
            {
                lblDescription.Text = value;
            }
        }

        /// <summary>
        /// Returns the selected Command Link Item
        /// </summary>
        public CommandLink SelectedCommandLink
        {
            get
            {
                return mSelectedCommandLink;
            }
        }
        
        /// <summary>
        /// Returns the index number of the SelectedCommandButton
        /// </summary>
        public Int32 SelectedCommandLinkIndex
        {
            get
            {
                return this.CommandLinks.IndexOf(mSelectedCommandLink);
            }
        }

        /// <summary>
        /// Provies a List ob CommandLink Objects. Each of them is a Clickable button within the CommandDialog
        /// </summary>
        public List<CommandLink> CommandLinks
        {
            get
            {
                return mCommandLinks;
            }
            set
            {

                while (mCommandLinks.Count > 0)
                {
                    mCommandLinks[0].Selected -= CommandLinkSelected;
                    this.Controls.Remove(mCommandLinks[0]);
                }

                mCommandLinks = value;
                if (mCommandLinks == null || mCommandLinks.Count == 0)
                {
                    return;
                }

                Point oLinkLocation = new Point(16, 100);
                Int32 lLinkHeight = -1;

                foreach (CommandLink oLink in mCommandLinks)
                {
                    this.Controls.Add(oLink);

                    oLink.Click += CommandLinkSelected;
                    oLink.Location = oLinkLocation;
                    oLinkLocation.Y += oLink.Height;
                    if (lLinkHeight == -1)
                    {
                        lLinkHeight = oLink.Height;
                    }
                }

                Int32 lHeight = 100 + ((mCommandLinks.Count + 1) * lLinkHeight);
                if (ShowCancelButton == true)
                {
                    lHeight += pnlBottom.Height;
                }
                this.Height = lHeight;

            }
        }
        /// <summary>
        /// True if a Cancelbutton should be shown, false otherwise.
        /// </summary>
        public bool ShowCancelButton
        {
            get
            {
                return mShowCancelButton;
            }
            set
            {
                bool bInv = false;
                if (mShowCancelButton != value)
                {
                    bInv = true;
                }
                mShowCancelButton = value;
                if (bInv)
                {
                    switch (mShowCancelButton)
                    {
                        case true:
                            this.Height += 41;
                            pnlBottom.Visible = true;
                            base.CancelButton = btnCancel;
                            break;
                        case false:
                            this.Height -= 41;
                            pnlBottom.Visible = false;
                            if (object.ReferenceEquals(base.CancelButton, btnCancel))
                            {
                                base.CancelButton = null;
                            }

                            break;
                    }
                    this.Invalidate();
                }
            }
        }
        /// <summary>
        /// Stellt einen Abbrechen-Button des Dialoges bereit
        /// </summary>
        public new IButtonControl CancelButton
        {
            get
            {
                return base.CancelButton;
            }
            set
            {
                bool bInv = false;
                if ((!object.ReferenceEquals(base.CancelButton, value)))
                {
                    bInv = true;
                }
                base.CancelButton = value;
                if (bInv)
                {
                    if (object.ReferenceEquals(base.CancelButton, btnCancel))
                    {
                        ShowCancelButton = true;
                    }
                    else
                    {
                        ShowCancelButton = false;
                    }
                    this.Invalidate();
                }
            }
        }
        #endregion

        #region " Overridden Events "
        /// <summary>
        /// Dialog is activated
        /// </summary>
        /// <param name="e"></param>
        protected override void OnActivated(System.EventArgs e)
        {
            base.OnActivated(e);
            ActivateCommandLinks(true);
        }

        /// <summary>
        /// Dialog losts its active state
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDeactivate(System.EventArgs e)
        {
            base.OnDeactivate(e);
            ActivateCommandLinks(false);
        }

        /// <summary>
        /// Dialog closed
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosed(System.EventArgs e)
        {
            foreach (CommandLink oLink in mCommandLinks)
            {
                oLink.Selected -= CommandLinkSelected;
            }
            base.OnClosed(e);
        }

        #endregion

        #region " Events "

        private void pnlBottom_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Pen oPen = new Pen(Color.FromArgb(223, 223, 223));
            e.Graphics.DrawLine(oPen, this.ClientRectangle.X, this.ClientRectangle.Y, this.ClientRectangle.X + this.ClientRectangle.Width, this.ClientRectangle.Y);
            oPen.Dispose();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        #endregion

        #region " Private Methods "

        private void ActivateCommandLinks(bool active)
        {
            foreach (CommandLink oLink in mCommandLinks)
            {
                oLink.ActivateChanged(active);
            }
        }

        private void CommandLinkSelected(object sender, System.EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            if (sender != null && sender is CommandLink)
            {
                mSelectedCommandLink = (CommandLink)sender;
                mSelectedCommandID = mCommandLinks.IndexOf((CommandLink)sender);
            }
            this.Close();
        }

        #endregion

    }
}