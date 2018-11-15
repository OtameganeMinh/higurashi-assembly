using Assets.Scripts.Core.Buriko;
using MOD.Scripts.Core;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI.Tips
{
	public static class TipsData
	{
		public static List<TipsDataEntry> Tips = new List<TipsDataEntry>
		{
			new TipsDataEntry
			{
				Id = 0,
				Script = "onik_tips_01",
				UnlockChapter = 1,
				Title = "Sao lớp học tùm lum thập cẩm thế này?",
				TitleJp = "うちって学年混在？"
			},
			new TipsDataEntry
			{
				Id = 1,
				Script = "onik_tips_02",
				UnlockChapter = 1,
				Title = "Trường mình không có đồng phục à?",
				TitleJp = "うちって制服自由？"
			},
			new TipsDataEntry
			{
				Id = 2,
				Script = "onik_tips_03",
				UnlockChapter = 2,
				Title = "Đại dinh cơ Maebara",
				TitleJp = "前原屋敷"
			},
			new TipsDataEntry
			{
				Id = 3,
				Script = "onik_tips_04",
				UnlockChapter = 2,
				Title = "Vụ giết người chặt xác ở công trường xây đập",
				TitleJp = "ダム現場のバラバラ殺人（新聞版）"
			},
			new TipsDataEntry
			{
				Id = 4,
				Script = "onik_tips_05",
				UnlockChapter = 3,
				Title = "Dự án phát triển thủy điện tại Hinamizawa",
				TitleJp = "雛見沢ダム計画"
			},
			new TipsDataEntry
			{
				Id = 5,
				Script = "onik_tips_06",
				UnlockChapter = 3,
				Title = "Bài báo lá cải",
				TitleJp = "週刊誌の特集記事"
			},
			new TipsDataEntry
			{
				Id = 6,
				Script = "onik_tips_07",
				UnlockChapter = 4,
				Title = "Nghe tên Rena cứ kì kì ấy nhỉ?",
				TitleJp = "レナってどういう名前だよ？"
			},
			new TipsDataEntry
			{
				Id = 7,
				Script = "onik_tips_08",
				UnlockChapter = 5,
				Title = "Bảng cáo thị",
				TitleJp = "回覧板"
			},
			new TipsDataEntry
			{
				Id = 8,
				Script = "onik_tips_09",
				UnlockChapter = 7,
				Title = "Vụ vợ chồng ủng hộ xây đập gặp tai nạn",
				TitleJp = "北条両親の転落事故"
			},
			new TipsDataEntry
			{
				Id = 9,
				Script = "onik_tips_10",
				UnlockChapter = 7,
				Title = "Vụ vị pháp sư qua đời vì bệnh tật",
				TitleJp = "古手神社の神主の病死"
			},
			new TipsDataEntry
			{
				Id = 10,
				Script = "onik_tips_11",
				UnlockChapter = 7,
				Title = "Vụ bà nội trợ bị đánh chết",
				TitleJp = "主婦殺人事件"
			},
			new TipsDataEntry
			{
				Id = 11,
				Script = "onik_tips_12",
				UnlockChapter = 7,
				Title = "Nhiệm vụ giữa đêm khuya",
				TitleJp = "無線記録"
			},
			new TipsDataEntry
			{
				Id = 12,
				Script = "onik_tips_13",
				UnlockChapter = 8,
				Title = "Có nhiều hơn bốn hung thủ?",
				TitleJp = "犯人は４人以上？"
			},
			new TipsDataEntry
			{
				Id = 13,
				Script = "onik_tips_14",
				UnlockChapter = 8,
				Title = "Hồ sơ nạn nhân",
				TitleJp = "捜査メモ"
			},
			new TipsDataEntry
			{
				Id = 14,
				Script = "onik_tips_15",
				UnlockChapter = 9,
				Title = "Công văn của Cảnh sát trưởng",
				TitleJp = "本部長通達"
			},
			new TipsDataEntry
			{
				Id = 15,
				Script = "onik_tips_16",
				UnlockChapter = 10,
				Title = "Có chất kích thích gây tự tử không?",
				TitleJp = "自殺を誘発するクスリは？"
			},
			new TipsDataEntry
			{
				Id = 16,
				Script = "onik_tips_17",
				UnlockChapter = 10,
				Title = "Lời hăm dọa",
				TitleJp = "脅迫"
			},
			new TipsDataEntry
			{
				Id = 17,
				Script = "onik_tips_18",
				UnlockChapter = 11,
				Title = "Có vẻ cậu ấy không được khỏe nhỉ...",
				TitleJp = "元気ないね。"
			},
			new TipsDataEntry
			{
				Id = 18,
				Script = "onik_tips_19",
				UnlockChapter = 13,
				Title = "Đa nhân cách???",
				TitleJp = "二重人格？？？"
			},
			new TipsDataEntry
			{
				Id = 19,
				Script = "onik_tips_20",
				UnlockChapter = 13,
				Title = "Ở Siêu thị Chú Bảy",
				TitleJp = "セブンスマ\u30fcトにて"
			}
		};

		public static TipsDataGroup GetVisibleTips(bool onlyNew, bool global)
		{
			TipsDataGroup tipsDataGroup = new TipsDataGroup();
			BurikoMemory instance = BurikoMemory.Instance;
			if (global)
			{
				int num = instance.GetGlobalFlag("GOnikakushiDay").IntValue();
				{
					foreach (TipsDataEntry tip in MODSystem.instance.modTipsController.Tips)
					{
						tipsDataGroup.TipsAvailable++;
						if (tip.UnlockChapter <= num)
						{
							tipsDataGroup.TipsUnlocked++;
							tipsDataGroup.Tips.Add(tip);
						}
					}
					return tipsDataGroup;
				}
			}
			int num2 = instance.GetFlag("LOnikakushiDay").IntValue();
			Debug.Log("current chapter " + num2);
			foreach (TipsDataEntry tip2 in MODSystem.instance.modTipsController.Tips)
			{
				if (onlyNew)
				{
					if (tip2.UnlockChapter == num2)
					{
						tipsDataGroup.TipsAvailable++;
						tipsDataGroup.TipsUnlocked++;
						tipsDataGroup.Tips.Add(tip2);
					}
				}
				else if (tip2.UnlockChapter <= num2)
				{
					tipsDataGroup.TipsAvailable++;
					tipsDataGroup.TipsUnlocked++;
					tipsDataGroup.Tips.Add(tip2);
				}
			}
			return tipsDataGroup;
		}
	}
}
