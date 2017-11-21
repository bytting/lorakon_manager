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
    public class SpectrumInfo
    {
        public SpectrumInfo()
        {
        }

        public Guid ID { get; set; }
        public Guid AccountID { get; set; }
        public string AccountName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime AcquisitionDate { get; set; }
        public DateTime ReferenceDate { get; set; }
        public string Filename { get; set; }
        public string BackgroundFile { get; set; }
        public string LibraryFile { get; set; }
        public float Sigma { get; set; }
        public string SampleType { get; set; }
        public string SampleComponent { get; set; }
        public int Livetime { get; set; }
        public string Laboratory { get; set; }
        public string Operator { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public float Altitude { get; set; }
        public string LocationType { get; set; }
        public string Location { get; set; }
        public string Community { get; set; }
        public float SampleWeight { get; set; }
        public string SampleWeightUnit { get; set; }
        public string SampleGeometry { get; set; }
        public string ExternalID { get; set; }
        public bool Approved { get; set; }
        public string ApprovedStatus { get; set; }
        public bool Rejected { get; set; }
        public string Comment { get; set; }
    }
}