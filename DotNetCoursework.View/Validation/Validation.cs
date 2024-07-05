using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotNetCoursework.View.Validation
{
    internal class Validation
    {
        public static bool IsValid(ErrorProvider errorProvider)
        {
            foreach (Control c in errorProvider.ContainerControl.Controls)
                if (errorProvider.GetError(c) != "")
                    return false;
            return true;
        }

    }
}
