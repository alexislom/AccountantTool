﻿using System.Collections.Generic;

namespace AccountantTool.Model
{
    public class AccountantRecord
    {
        public int Id { get; set; }

        public Company Company { get; set; }

        public Requisites Requisites { get; set; }

        public List<ContactPerson> ContactPersons { get; set; }

        public List<License> License { get; set; }

        public List<Product> Products { get; set; }

        public Contract Contract { get; set; }

        public AdditionalInfo AdditionalInfo { get; set; }

        #region Override Methods
        
        /// <summary>
        /// This method need for filter search.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            //return $"{Company.LongName}, {Requisites}, {ContactPerson}, {License}, {Product}, {Contract}, {AdditionalInfo}".ToLower();
            //return $"{Company.LongName}".ToLower();
            return "Test string";
        }
        #endregion Override Methods
    }
}