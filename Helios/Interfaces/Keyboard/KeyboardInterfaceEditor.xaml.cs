//  Copyright 2014 Craig Courtney
//    
//  Helios is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  Helios is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

namespace GadrocsWorkshop.Helios.Interfaces.Keyboard
{
    using GadrocsWorkshop.Helios.Windows.Controls;

    /// <summary>
    /// Interaction logic for KeyboardInterfaceEditor.xaml
    /// </summary>
    public partial class KeyboardInterfaceEditor : HeliosInterfaceEditor
    {
        public KeyboardInterfaceEditor()
        {
            InitializeComponent();
        }

        #region Properties

        public string SpecialKeysText
        {
            get { return KeyboardInterface.SpecialKeyHelp; }
        }
        
        #endregion
    }
}
