using Notes.Tests.Common;
using Xunit;
using Notes.Application.Notes.Commands.UpdateNote;
using Microsoft.EntityFrameworkCore;
using Notes.Test.Common;

namespace Notes.Test.Notes
{
    public class ChangeTenUserTest : TestCommandBase
	{
		[Fact]
		public async Task ChangeTenUser_Success()
		{
            //Arrange			
            var handle = new UpdateNoteCommandHandler(Context);
            float updateBallance = 50;
			//Act
			List<int> randomUserId = RandomShuffle.GetRandomShuffleNumbers(10);
			for (int i = 0; i < randomUserId.Count; i++)
			{				
				var noteUserID = await handle.Handle(
					new UpdateNoteCommand
					{					
						UserId = NotesContextFactory.UserAId[randomUserId[i]],
						Ballance = updateBallance
					}
					, CancellationToken.None);
			}

			// Assert
			for (int i = 0; i < randomUserId.Count; i++)
			{
				Assert.NotNull(await Context.Notes.SingleOrDefaultAsync(note =>
					note.UserId == NotesContextFactory.UserAId[randomUserId[i]] &&
					note.Ballance == NotesContextFactory.startBallance + randomUserId[i] + updateBallance));
			}
		}

	}
}
