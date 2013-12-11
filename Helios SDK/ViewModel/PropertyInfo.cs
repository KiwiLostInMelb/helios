﻿//  Copyright 2013 Craig Courtney
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

namespace GadrocsWorkshop.Helios.ViewModel
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// Meta data flags for special actions which should be taken on property changes.
    /// </summary>
    [Flags]
    public enum PropertyInfo
    {
        None = 0,
        [Description("Changes to this property are recorded in the undo buffer.")]
        Undoable,
        [Description("When this property changes it forces a clear of the undo buffer.")]
        UndoClear,
        [Description("This property should refresh the displayname property.")]
        DisplayName
    }
}