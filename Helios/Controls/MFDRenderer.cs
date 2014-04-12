﻿//  Copyright 2014 Craig Courtney
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

namespace GadrocsWorkshop.Helios.Controls
{
    using GadrocsWorkshop.Helios.ComponentModel;
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Media;

    class MFDRenderer : HeliosVisualRenderer
    {
        private ImageBrush _bezel;
        private Rect _bezelRectangle;

        protected override void OnRender(System.Windows.Media.DrawingContext drawingContext)
        {
            MFD mfd = Visual as MFD;

            if (mfd != null)
            {
                drawingContext.DrawRectangle(_bezel, null, _bezelRectangle);
            }
        }

        protected override void OnRefresh()
        {
            MFD mfd = Visual as MFD;

            if (mfd != null)
            {
                _bezelRectangle = new Rect(0, 0, mfd.Width, mfd.Height);

                _bezel = CreateImageBrush(mfd.BezelImage);
            }
            else
            {
                _bezel = null;
            }
        }

        private ImageBrush CreateImageBrush(string imagefile)
        {
            ImageSource image = ConfigManager.ImageManager.LoadImage(imagefile);

            if (image != null)
            {
                ImageBrush imageBrush = new ImageBrush(image);
                imageBrush.Stretch = Stretch.Fill;
                imageBrush.TileMode = TileMode.None;
                imageBrush.Viewport = new Rect(0d, 0d, 1d, 1d);
                imageBrush.ViewportUnits = BrushMappingMode.RelativeToBoundingBox;

                return imageBrush;
            }

            return null;
        }
    }
}
