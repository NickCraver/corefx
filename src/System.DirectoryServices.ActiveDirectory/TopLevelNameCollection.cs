//------------------------------------------------------------------------------
// <copyright file="TopLevelNameCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

/*
 */

  namespace System.DirectoryServices.ActiveDirectory {
    using System;
    using System.Runtime.InteropServices;
    using System.Collections;
    using System.Globalization;

    public class TopLevelNameCollection :ReadOnlyCollectionBase {
        internal TopLevelNameCollection() {}

        public TopLevelName this[int index] {
            get {
                return (TopLevelName) InnerList[index];
            }            
        }
        
        public bool Contains(TopLevelName name)
        {
            if(name == null)
                throw new ArgumentNullException("name");
            
            return InnerList.Contains(name);
        }

        public int IndexOf(TopLevelName name) {
            if(name == null)
                throw new ArgumentNullException("name");
            
            return InnerList.IndexOf(name);
        } 

        public void CopyTo(TopLevelName[] names, int index) {
            InnerList.CopyTo(names, index);
        }      

        internal int Add(TopLevelName name)
        {
            if(name == null)
                throw new ArgumentNullException("name");

            return InnerList.Add(name);            
        }
    }
}
