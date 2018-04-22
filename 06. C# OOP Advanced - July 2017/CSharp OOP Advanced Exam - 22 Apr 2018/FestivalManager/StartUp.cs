namespace FestivalManager
{
    using Core;
    using Core.Controllers;
    using Core.Controllers.Contracts;
    using Core.IO;
    using Core.IO.Contracts;
    using Entities;

    public static class StartUp
	{
		public static void Main()
		{
            IReader reader = new Reader();
            IWriter writer = new Writer();

			Stage stage = new Stage();

            ISetController setController = new SetController(stage);
            IFestivalController festivalController = new FestivalController(stage);

			var engine = new Engine(reader, writer, setController, festivalController);

			engine.Run();
		}
	}
}