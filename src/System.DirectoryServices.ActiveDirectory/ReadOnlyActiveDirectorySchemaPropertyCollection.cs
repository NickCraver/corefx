//------------------------------------------------------------------------------
// <copyright file="ReadOonlyActiveDirectorySchemaPropertyCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

namespace System.DirectoryServices.ActiveDirectory {
	using System;
	using System.Globalization;
	using System.Collections;

	public class ReadOnlyActiveDirectorySchemaPropertyCollection: ReadOnlyCollectionBase {
		
		internal ReadOnlyActiveDirectorySchemaPropertyCollection() { }

		internal ReadOnlyActiveDirectorySchemaPropertyCollection(ArrayList values) {
			if (values != null) {
				InnerList.AddRange(values);
			}
		}

		public ActiveDirectorySchemaProperty this[int index] {
			get {
				return (ActiveDirectorySchemaProperty)InnerList[index];                                  
			}
		}

		public bool Contains(ActiveDirectorySchemaProperty schemaProperty) {

                      if (schemaProperty == null)
				throw new ArgumentNullException("schemaProperty");
            
            
			for (int i = 0; i < InnerList.Count; i++) {
				ActiveDirectorySchemaProperty tmp = (ActiveDirectorySchemaProperty)InnerList[i];
				if (Utils.Compare(tmp.Name, schemaProperty.Name) == 0) {
					return true;
				}
			}
			return false;
		}                               

		public int IndexOf(ActiveDirectorySchemaProperty schemaProperty) {

                      if (schemaProperty == null)
				throw new ArgumentNullException("schemaProperty");
            
			for (int i = 0; i < InnerList.Count; i++) {
				ActiveDirectorySchemaProperty tmp = (ActiveDirectorySchemaProperty)InnerList[i];
				if (Utils.Compare(tmp.Name, schemaProperty.Name) == 0) {
					return i;
				}
			}
			return -1;
		}     

		public void CopyTo(ActiveDirectorySchemaProperty[] properties, int index) {
			InnerList.CopyTo(properties, index);
		}
	}
}
