using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
namespace OnlineStoreWebApplication
{
    public class ValidationClass
    {

        public Boolean NotEmpty(TextBox inst)
        {
            if (inst.Text.Equals(""))
            {
                //failed
                return false;
            }
            else
            {
                //success
                return true;
            }
        }

        public Boolean NotEmpty(DropDownList inst)
        {
            if (inst.SelectedIndex.Equals(0))
            {
                //failed
                return false;
            }
            else
            {
                //success
                return true;
            }
        }

        //-----------------------------------------------------
        public Boolean IntegerIsValid(TextBox instance)
        {
            char[] array = instance.Text.ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 49 || array[i] > 57)
                {
                    return false;
                }
            }

            return true;
        }
    }
}