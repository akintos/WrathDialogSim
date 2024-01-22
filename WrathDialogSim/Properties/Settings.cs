using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WrathDialogSim.Properties
{
    internal partial class Settings
    {
        public Settings()
        {
            PropertyChanged += SettingsPropertyChangedHandler;
        }

        private void SettingsPropertyChangedHandler(object sender, PropertyChangedEventArgs e)
        {
            Save();
        }
    }
}
