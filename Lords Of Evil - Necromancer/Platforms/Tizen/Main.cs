using System;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace Lords_Of_Evil___Necromancer;

class Program : MauiApplication
{
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

	static void Main(string[] args)
	{
		var app = new Program();
		app.Run(args);
	}
}
