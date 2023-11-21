using System;
using Notes.Persistence;
using Notes.Tests.Common;

namespace Notes.Tests.Common
{
	public abstract class TestCommandBase : IDisposable
	{
		protected readonly NotesDbContext Context;

		public TestCommandBase()
		{
			Context = NotesContextFactory.Create();
		}

		public void Dispose()
		{
			
				NotesContextFactory.Destroy(Context);
			
		}
	}
}
