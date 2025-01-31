﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JadeKhalid_Project.Controllers
{
    public class Q2Controller : ApiController
    {
        /* User selects an indicator from a dropdown list. We get 
         * all the countries that have an especially good score 
         * (lower is good, so 3 or lower?) in that indicator */
        SfiHdiEntitiesConnection myCollection = new SfiHdiEntitiesConnection();

        public IHttpActionResult GetCountriesStrongScore(string id)
        {
            List<int> mySfiIds = new List<int>();
            List<int> myCountryIds = new List<int>();
            List<string> myCountryNames = new List<string>();

            if (id == "Security Apparatus")
            {
                foreach (Indicator ind in myCollection.Indicators)
                {
                    if (ind.sfiSec <= 3)
                    {
                        mySfiIds.Add(ind.sfiID);
                    }
                }
            }
            else if (id == "Factionalized Elites")
            {
                foreach (Indicator ind in myCollection.Indicators)
                {
                    if (ind.sfiFaction <= 3)
                    {
                        mySfiIds.Add(ind.sfiID);
                    }
                }
            }
            else if (id == "Group Grievance")
            {
                foreach (Indicator ind in myCollection.Indicators)
                {
                    if (ind.sfiGgriev <= 3)
                    {
                        mySfiIds.Add(ind.sfiID);
                    }
                }
            }
            else if (id == "Economy")
            {
                foreach (Indicator ind in myCollection.Indicators)
                {
                    if (ind.sfiEcon <= 3)
                    {
                        mySfiIds.Add(ind.sfiID);
                    }
                }
            }
            else if (id == "Economic Inequality")
            {
                foreach (Indicator ind in myCollection.Indicators)
                {
                    if (ind.sfiEcIneq <= 3)
                    {
                        mySfiIds.Add(ind.sfiID);
                    }
                }
            }
            else if (id == "Human Flight and Brain Drain")
            {
                foreach (Indicator ind in myCollection.Indicators)
                {
                    if (ind.sfihFlight <= 3)
                    {
                        mySfiIds.Add(ind.sfiID);
                    }
                }
            }
            else if (id == "State Legitimacy")
            {
                foreach (Indicator ind in myCollection.Indicators)
                {
                    if (ind.sfisLegit <= 3)
                    {
                        mySfiIds.Add(ind.sfiID);
                    }
                }
            }
            else if (id == "Public Services")
            {
                foreach (Indicator ind in myCollection.Indicators)
                {
                    if (ind.sfiPub <= 3)
                    {
                        mySfiIds.Add(ind.sfiID);
                    }
                }
            }
            else if (id == "Human Rights")
            {
                foreach (Indicator ind in myCollection.Indicators)
                {
                    if (ind.sfiRights <= 3)
                    {
                        mySfiIds.Add(ind.sfiID);
                    }
                }
            }
            else if (id == "Demographic Pressures")
            {
                foreach (Indicator ind in myCollection.Indicators)
                {
                    if (ind.sfiDem <= 3)
                    {
                        mySfiIds.Add(ind.sfiID);
                    }
                }
            }
            else if (id == "Refugees and IDPs")
            {
                foreach (Indicator ind in myCollection.Indicators)
                {
                    if (ind.sfiRef <= 3)
                    {
                        mySfiIds.Add(ind.sfiID);
                    }
                }
            }
            else if (id == "External Intervention")
            {
                foreach (Indicator ind in myCollection.Indicators)
                {
                    if (ind.sfiExtInt <= 3)
                    {
                        mySfiIds.Add(ind.sfiID);
                    }
                }
            }

            foreach (SFI s in myCollection.SFIs)
            {
                foreach (int sId in mySfiIds)
                {
                    if (s.sfiID == sId)
                    {
                        myCountryIds.Add(s.countryID);
                    }
                }
            }

            foreach (Country c in myCollection.Countries)
            {
                foreach (int cId in myCountryIds)
                {
                    if (c.CountryID == cId)
                    {
                        myCountryNames.Add(c.countryName);
                    }
                }
            }

            return Json(myCountryNames);
        }

    }
}
