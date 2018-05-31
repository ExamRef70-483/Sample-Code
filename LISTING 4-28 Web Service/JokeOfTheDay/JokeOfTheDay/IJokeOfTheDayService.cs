using System.ServiceModel;

namespace JokeOfTheDay
{
    [ServiceContract]
    public interface IJokeOfTheDayService
    {
        [OperationContract]
        string GetJoke(int jokeStrength);
    }
}
