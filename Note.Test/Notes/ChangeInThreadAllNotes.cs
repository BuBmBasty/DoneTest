using Notes.Tests.Common;
using Xunit;
using Notes.Application.Notes.Commands.UpdateNote;
using Microsoft.EntityFrameworkCore;
using Notes.Test.Common;
using System.Reflection.Metadata;
using System.Threading;

namespace Notes.Test.Notes
{

    public class ChangeInThreadAllNotes: TestCommandBase
    {        
        static volatile int starterCount = 0;               // Счётчик запущенных потоков. volatile показывает, что переменная будет изменяться в различных потоках и её не надо оптимизировать
       
        static int threadCount = 2;
        float updateBallance = 50;

        [Fact]
        public void ChangeTenUser_Success()
        {
            //Arrange			
            var handle = new UpdateNoteCommandHandler(Context);
            List<Thread> threads = new List<Thread>(threadCount);
           
            //Act

            for (int i = 0; i < threads.Count; i++)                             //создал пул потоков
            {
                Thread thread = new Thread(HandleUpdate);
                threads.Add(thread);
            }
            
            foreach (var thread in threads)                                       //Запустил пул потоков
            {
                thread.Start();
            }
        }  
        
        private async void HandleUpdate()
        {
            var handle = new UpdateNoteCommandHandler(Context);
            for (int i = 0; i < 50; i++)
            {
                await handle.Handle(
                   new UpdateNoteCommand
                   {
                       UserId = NotesContextFactory.UserAId[i],
                       Ballance = updateBallance
                   }
                   , CancellationToken.None);
            }

            starterCount++;                                                                                 //Плюсуем выполненный поток

            if (starterCount >= threadCount-1)                                                                //Если все потоки выполнены - запускаем проверку
                ActDone();
        }

        private async void ActDone()
        {
            // Assert
            for (int i = 0; i < 50; i++)
            {
                Assert.NotNull(await Context.Notes.SingleOrDefaultAsync(note =>
                    note.UserId == NotesContextFactory.UserAId[i]));
                Assert.NotNull(await Context.Notes.SingleOrDefaultAsync(note =>
                  note.Ballance == NotesContextFactory.startBallance + i + threadCount * updateBallance));
            }
        }

    }
}
