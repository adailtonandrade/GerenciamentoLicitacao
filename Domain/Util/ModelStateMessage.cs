using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Util
{
    public class ModelStateMessage
    {
        public static dynamic AddModelStateError(List<string> errors, string key, dynamic myModel)
        {
            foreach (string error in errors)
            {
                if (key != string.Empty)
                    myModel.AddModelError(key, error);
                else
                    myModel.AddModelError(string.Empty, error);
            }
            return myModel;
        }
    }
}
