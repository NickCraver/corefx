//------------------------------------------------------------------------------
// <copyright file="ApplicationPartitionCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

namespace System.DirectoryServices.ActiveDirectory {
	using System;
	using System.Collections;
	using System.Globalization;
	using System.DirectoryServices;

	public class ApplicationPartitionCollection: ReadOnlyCollectionBase {

		internal ApplicationPartitionCollection() { }
	
		internal ApplicationPartitionCollection(ArrayList values) {
			if (values != null) {
				InnerList.AddRange(values);
			}
		}

		public ApplicationPartition this[int index] {
			get {
				return (ApplicationPartition)InnerList[index];                             
			}
		}

		public bool Contains(ApplicationPartition applicationPartition) {

                     if (applicationPartition == null) {
                            throw new ArgumentNullException("applicationPartition");   
                     }
                     
			for (int i = 0; i < InnerList.Count; i++) {
				ApplicationPartition tmp = (ApplicationPartition)InnerList[i];
				if (Utils.Compare(tmp.Name, applicationPartition.Name) == 0) {
					return true;
				}
			}
			return false;
		}                                

		public int IndexOf(ApplicationPartition applicationPartition) {

                     if (applicationPartition == null) {
                            throw new ArgumentNullException("applicationPartition");   
                     }
            
			for (int i = 0; i < InnerList.Count; i++) {
				ApplicationPartition tmp = (ApplicationPartition)InnerList[i];
				if (Utils.Compare(tmp.Name, applicationPartition.Name) == 0) {
					return i;
				}
			}
			return -1;
		}     

		public void CopyTo(ApplicationPartition[] applicationPartitions, int index) {
			InnerList.CopyTo(applicationPartitions, index);
		}
	}
}
