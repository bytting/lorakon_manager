//  lorakon_manager - Manager for Lorakon database
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
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lorakon_manager
{
    [Serializable()]
    public class Settings
    {        
        public string ConnectionString { get; set; }        

        public Settings()
        {            
            ConnectionString = "Server=zyrox3;Database=nrpa_lorakon;Trusted_Connection=True;";            
        }
    }    
}
