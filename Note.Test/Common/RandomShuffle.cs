using Notes.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Test.Common
{
	public class RandomShuffle
	{
		private static Random _rand = new Random((int)(DateTime.Now.Ticks));			//минимальная возможность повторения
		
		public static List<int> GetRandomShuffleNumbers(int cont)
		{
			List<int> _shuffleNumbers = new List<int>();                 //лист для внесения инт
		    int _finderInt;
		    bool _isFindInt;
		
			if (cont >= NotesContextFactory.UserAId.Length) 
			{
				cont = NotesContextFactory.UserAId.Length;
			}
			for (int i= 0;i<cont;i++)
			{
				_isFindInt = false;
				_finderInt = _rand.Next(0,NotesContextFactory.UserAId.Length);  //находим случайный инт

				for (int j= 0;j<_shuffleNumbers.Count;j++)						//проверяем на повтор
				{
					if (_finderInt == _shuffleNumbers[j])
					{
						_isFindInt = false;
						break;
					}
					_isFindInt = true;
				}

				if (_isFindInt)													//если повторов нет - вносим
				{
					_shuffleNumbers.Add(_finderInt);
				}
			}
			return _shuffleNumbers;
		}
	}
}
