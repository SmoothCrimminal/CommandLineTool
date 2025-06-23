using CommandLineTool.Api;
using CommandLineTool.Commands.Abstraction;

namespace CommandLineTool.Commands
{
    public class JokeCommand : IAsyncCommand
    {
        public string Name => "joke";

        private readonly JokeApiService _jokeApiService;

        public JokeCommand(JokeApiService jokeApiService)
        {
            _jokeApiService = jokeApiService;
        }

        public async Task ExecuteAsync()
        {
            var joke = await _jokeApiService.GetRandomJokeAsync();
            if (joke is null)
            {
                Console.WriteLine("There was a problem with retrieving a joke");
                return;
            }

            Console.WriteLine(joke.Setup);
            Console.WriteLine(joke.Punchline);
        }
    }
}
