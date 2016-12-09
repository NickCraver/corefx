using System;
using System.Collections.Generic;
using System.Text;


namespace System.DirectoryServices.AccountManagement
{

    internal class ExtensionHelper
    {
        internal  ExtensionHelper(Principal p)
        {
            this.p = p;
        }

        Principal p;
        
        internal string RdnPrefix
        {
            // <SecurityKernel Critical="True" Ring="0">
            // <SatisfiesLinkDemand Name="Principal.get_ContextType():System.DirectoryServices.AccountManagement.ContextType" />
            // </SecurityKernel>
            [System.Security.SecurityCritical]
            get
            {
                DirectoryRdnPrefixAttribute [] MyAttribute =
                (DirectoryRdnPrefixAttribute [])Attribute.GetCustomAttributes(p.GetType(), typeof(DirectoryRdnPrefixAttribute), false );

                if (MyAttribute == null)
                    return null;

                string defaultRdn = null;
                
                for (int i = 0; i < MyAttribute.Length; i++)
                {
                    if (MyAttribute[i].Context == null && null == defaultRdn )
                    {
                        defaultRdn = MyAttribute[i].RdnPrefix;
                    }
                    if (p.ContextType == MyAttribute[i].Context)
                    {
                        return MyAttribute[i].RdnPrefix;
                    }
                }

                return defaultRdn;
            }
        }
        
        static internal string ReadStructuralObjectClass(Type principalType)
        {
            DirectoryObjectClassAttribute [] MyAttribute =
            (DirectoryObjectClassAttribute [])Attribute.GetCustomAttributes( principalType, typeof(DirectoryObjectClassAttribute), false );

            if (MyAttribute == null)
                return null;

            string defaultObjectClass = null;
            
            for (int i = 0; i < MyAttribute.Length; i++)
            {
                if (MyAttribute[i].Context == null && null == defaultObjectClass)
                {
                    defaultObjectClass = MyAttribute[i].ObjectClass;
                }
                /*
                if (p.ContextType == MyAttribute[i].Context)
                {
                    return MyAttribute[i].ObjectClass;
                }
                */
            }

            return defaultObjectClass;
        }
        
        internal string StructuralObjectClass
        {
            // <SecurityKernel Critical="True" Ring="0">
            // <SatisfiesLinkDemand Name="Principal.get_ContextType():System.DirectoryServices.AccountManagement.ContextType" />
            // </SecurityKernel>
            [System.Security.SecurityCritical]
            get
            {
                DirectoryObjectClassAttribute [] MyAttribute =
                (DirectoryObjectClassAttribute [])Attribute.GetCustomAttributes(p.GetType(), typeof(DirectoryObjectClassAttribute), false );

                if (MyAttribute == null)
                    return null;

                string defaultObjectClass = null;
                
                for (int i = 0; i < MyAttribute.Length; i++)
                {
                    if (MyAttribute[i].Context == null && null == defaultObjectClass )
                    {
                        defaultObjectClass = MyAttribute[i].ObjectClass;
                    }
                    if (p.ContextType == MyAttribute[i].Context)
                    {
                        return MyAttribute[i].ObjectClass;
                    }
                }

                return defaultObjectClass;
            }
        }
/*        
        internal string SchemaAttributeName(string propertyName)
        {            
            System.Reflection.PropertyInfo propInfo = this.GetType().GetProperty(propertyName);
            
            if ( null == propInfo )
                return null;
            
            DirectoryPropertyAttribute[] MyAttribute = (DirectoryPropertyAttribute[])Attribute.GetCustomAttributes(propInfo, typeof(DirectoryPropertyAttribute));

            if (MyAttribute == null)
                return null;

            string defaultAttribute = null;
            
            for (int i = 0; i < MyAttribute.Length; i++)
            {
                if (MyAttribute[i].Context == null)
                {
                    defaultAttribute = MyAttribute[i].SchemaAttributeName;
                }
                if (p.ContextType == MyAttribute[i].Context)
                {
                    return MyAttribute[i].SchemaAttributeName;
                }
            }

            return defaultAttribute;
            
        }
*/
        
      }
}

