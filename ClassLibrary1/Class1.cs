using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Approvals
{
    public class Class1 : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            IPluginExecutionContext context =
                (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));

            IOrganizationServiceFactory serviceFactory =
                (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));

            IOrganizationService service = (IOrganizationService)serviceFactory.CreateOrganizationService(context.UserId);

            if (context.Depth == 1)
            {
                if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity)
                {
                    Entity Age = (Entity)context.InputParameters["Target"];
                    Age = service.Retrieve("new_age", Age.Id, new ColumnSet(true));

                    Entity account = new Entity("account");

                  //  int  approval = ((int)FarmerOnboarding.Attributes["cr431_approval"]);
                  //  string farmerclose = FarmerOnboarding.Attributes["cr431_farmeronboardingclose"].ToString();
                  //  if (approval == 254460000 && farmerclose == "1")
                   // {
                        account.Attributes["name"] = Age.Attributes["new_name"];
                        account.Attributes["new_countcontact"] = Age.Attributes["new_description"];
                     //   account.Attributes["name"] = Age.Attributes["cr431_name"];
                //    }
                    service.Create(account);

                }
            }

        }
    }
}