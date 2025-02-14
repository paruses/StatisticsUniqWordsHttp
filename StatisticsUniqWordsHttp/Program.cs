﻿using System;
using NLog;

namespace StatisticsUniqWordsHttp
{
	class Program
	{
		private static Logger logger = LogManager.GetCurrentClassLogger();

		static void Main(string[] args)
		{
			try
			{
				logger.Trace("запуск приложения StatisticsUniqWordsHttp");
				WebPage webpage = new WebPage();
				webpage.UrlPage = "https://www.simbirsoft.com/";
				webpage.FileName = "test.html";
				//скачивание web-страницы на локальный диск
				logger.Trace("скачивание web-страницы на локальный диск");
				webpage.DownloadFile();
			
				StatisticFile file = new StatisticFile();
				//вывод статистики по количеству уникальных слов
				logger.Trace("begin вывод статистики по количеству уникальных слов");
				file.CountWords(webpage.LocalFile);
				logger.Trace("end вывод статистики по количеству уникальных слов");
			}
			catch (Exception ex)
			{
				logger.Error(ex.ToString());
			}

			Console.ReadKey();
		}
	}
}
