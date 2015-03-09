using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

    public class Building
    {
        private int buildingId;
        private string buildingName;
        public Building() { }
        public Building(int id, string name)
        {
            BuildingId = id;
            BuildingName = name;
        }
        public int BuildingId
        {
            get { return buildingId; }
            set { buildingId = value; }
        }

        public string BuildingName
        {
            get { return buildingName; }
            set { buildingName = value; }
        }
    }
