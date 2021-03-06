﻿//  lorakon_manager - Manager for Lorakon database
//  Copyright (C) 2017  Norwegian Radiation Protection Autority
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
//
// Authors: Dag Robole,

using System;
using System.Windows.Forms;
using System.Globalization;

namespace lorakon_manager
{        
    public static class CustomEvents
    {
        public static void Alpha_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow letters and numbers
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) 
                && !char.IsDigit(e.KeyChar) && !"-_".Contains(e.KeyChar.ToString());
        }

        public static void Integer_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow numbers
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        public static void Numeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow decimals            
            char sep = Convert.ToChar(CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator);

            TextBox tb = (TextBox)sender;
            if (e.KeyChar == sep)
            {
                // Only allow one separator
                foreach (char c in tb.Text)
                {
                    if (c == sep)
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }

            if (e.KeyChar == '-')
            {
                // Only allow one minus
                foreach (char c in tb.Text)
                {
                    if (c == '-')
                    {
                        e.Handled = true;
                        return;
                    }
                }

                if(tb.SelectionStart != 0)
                {
                    e.Handled = true;
                    return;
                }
            }

            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != sep && e.KeyChar != '-')
                e.Handled = true;
        }
    }    
}
