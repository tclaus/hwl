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
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Vista_Api.Dialog.Native;

namespace Vista_Api
{
    /// <summary>
    /// A ListView wise enough to display tooltips when needed.
    /// The tooltips are displayed over ListViewItem or ListViewSubItem.
    /// </summary>
    public class ListView : System.Windows.Forms.ListView
    {

        /// <summary>
        /// Handle Created
        /// </summary>
        /// <param name="e"></param>
        protected override void OnHandleCreated(System.EventArgs e)
        {
            base.OnHandleCreated(e);
            if (NativeMethods.IsVistaOrLater)
                NativeMethods.SetWindowTheme(this.Handle, "explorer", null);
        }
    }
}
