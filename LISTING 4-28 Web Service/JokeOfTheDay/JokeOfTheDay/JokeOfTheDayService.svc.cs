using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace JokeOfTheDay
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class JokeOfTheDayService : IJokeOfTheDayService
    {

        public string GetJoke(int jokeStrength)
        {
            string result = "Invalid strength";
            switch (jokeStrength)
            {
                case 0:
                    result = "Knock Knock. Who's there? Oh, you've heard it";
                    break;
                case 1:
                    result = "What's green and hairy and goes up and down? A gooseberry in a lift";
                    break;
                case 2:
                    result = "This horse walks into a bar and the barman asks 'Why the long face?'";
                    break;
            }
            return result;
        }
    }
}
