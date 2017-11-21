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

namespace lorakon_manager
{
    public class ValidationRule
    {
        public ValidationRule()
        {
            Id = Guid.Empty;
            NuclideName = String.Empty;
            ActivityMin = 0f;
            ActivityMax = 0f;
            ConfidenceMin = 0f;
            CanBeAutoApproved = false;
        }

        public ValidationRule(Guid id, string nuclideName, float activityMin, float activityMax, float confidenceMin, bool canBeAutoApproved)
        {
            Id = id;
            NuclideName = nuclideName;
            ActivityMin = activityMin;
            ActivityMax = activityMax;
            ConfidenceMin = confidenceMin;
            CanBeAutoApproved = canBeAutoApproved;
        }        

        public Guid Id { get; set; }
        public string NuclideName { get; set; }
        public float ActivityMin { get; set; }
        public float ActivityMax { get; set; }
        public float ConfidenceMin { get; set; }
        public bool CanBeAutoApproved { get; set; }
    }
}