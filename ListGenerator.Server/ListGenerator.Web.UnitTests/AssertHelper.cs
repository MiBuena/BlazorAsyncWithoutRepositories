using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListGenerator.Web.UnitTests
{
    public static class AssertHelper
    {
        public static void AssertAll(params Action[] assertionsToRun)
        {
            var errorMessages = new List<string>();

            foreach (var action in assertionsToRun)
            {
                try
                {
                    action.Invoke();
                }
                catch (Exception exc)
                {
                    errorMessages.Add(exc.Message);
                }
            }

            if (errorMessages.Any())
            {
                var separator = string.Format("{0}{0}", Environment.NewLine);
                string errorMessageString = string.Join(separator, errorMessages);

                throw new Exception(string.Format("The following condtions failed:{0}{1}",
                             Environment.NewLine, errorMessageString));
            }
        }
    }
}
