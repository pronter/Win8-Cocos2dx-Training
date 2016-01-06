using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;
using Project.ViewModel;
using Windows.Storage;



namespace Project
{
    class VModel : INotifyPropertyChanged
    {
        private ObservableCollection<card> mylist;
        private ObservableCollection<card> mylist1;
        private List<string> c1;
        private ObservableCollection<card> mylist2;
        private List<string> c2;
        private ObservableCollection<card> mylist3;
        private List<string> c3;
        private ObservableCollection<card> mylist4;
        private List<string> c4;
        private ObservableCollection<card> mylist5;
        private List<string> c5;
        private ObservableCollection<card> mylist6;
        private List<string> c6;
        private ObservableCollection<card> mylist7;
        private List<string> c7;
        private string all_txt;

        private Dictionary<string, Dictionary<string, string>> d;

  

        private int selectedItemIndex;


        public ObservableCollection<card> Group()
        {
            foreach (var i in d)
            {
                if (true)
                {
                    string st1 = i.Key;
                    string st2;
                    string st3;
                    Dictionary<string, string> myd = (Dictionary<string, string>)i.Value;
                    foreach (var j in myd)
                    {
                        st2 = j.Key;
                        st3 = j.Value;
                        MyList.Add(new card { Title = st1, ImagePath = new BitmapImage(new Uri("ms-appx:///" + "Assets/法师卡牌库/" + st1 + ".png")), Content = "类型：" + st2 + "\n稀有度：" + st3 });

                    }
                }
            }
            return MyList;
        }

        public ObservableCollection<card> Group1()
        {
            foreach (var i in d)
            {
                if (true)
                {
                    string st1 = i.Key;
                    if (!c1.Contains(st1)) continue;
                    string st2;
                    string st3;
                    Dictionary<string, string> myd = (Dictionary<string, string>)i.Value;
                    foreach (var j in myd)
                    {
                        st2 = j.Key;
                        st3 = j.Value;
                        MyList1.Add(new card { Title = st1, ImagePath = new BitmapImage(new Uri("ms-appx:///" + "Assets/法师卡牌库/" + st1 + ".png")), Content = "类型：" + st2 + "\n稀有度：" + st3 });
                        MyList1.Add(new card { Title = st1, ImagePath = new BitmapImage(new Uri("ms-appx:///" + "Assets/法师卡牌库/" + st1 + ".png")), Content = "类型：" + st2 + "\n稀有度：" + st3 });
                    }
                }
            }
            return MyList1;
        }

        public ObservableCollection<card> Group2()
        {
            foreach (var i in d)
            {
                if (true)
                {
                    string st1 = i.Key;
                    if (!c2.Contains(st1)) continue;
                    string st2;
                    string st3;
                    Dictionary<string, string> myd = (Dictionary<string, string>)i.Value;
                    foreach (var j in myd)
                    {
                        st2 = j.Key;
                        st3 = j.Value;
                        MyList2.Add(new card { Title = st1, ImagePath = new BitmapImage(new Uri("ms-appx:///" + "Assets/法师卡牌库/" + st1 + ".png")), Content = "类型：" + st2 + "\n稀有度：" + st3 });
                        MyList2.Add(new card { Title = st1, ImagePath = new BitmapImage(new Uri("ms-appx:///" + "Assets/法师卡牌库/" + st1 + ".png")), Content = "类型：" + st2 + "\n稀有度：" + st3 });
                    }
                }
            }
            return MyList2;
        }

        public ObservableCollection<card> Group3()
        {
            foreach (var i in d)
            {
                if (true)
                {
                    string st1 = i.Key;
                    if (!c3.Contains(st1)) continue;
                    string st2;
                    string st3;
                    Dictionary<string, string> myd = (Dictionary<string, string>)i.Value;
                    foreach (var j in myd)
                    {
                        st2 = j.Key;
                        st3 = j.Value;
                        MyList3.Add(new card { Title = st1, ImagePath = new BitmapImage(new Uri("ms-appx:///" + "Assets/法师卡牌库/" + st1 + ".png")), Content = "类型：" + st2 + "\n稀有度：" + st3 });
                        MyList3.Add(new card { Title = st1, ImagePath = new BitmapImage(new Uri("ms-appx:///" + "Assets/法师卡牌库/" + st1 + ".png")), Content = "类型：" + st2 + "\n稀有度：" + st3 });
                    }
                }
            }
            return MyList3;
        }

        public ObservableCollection<card> Group4()
        {
            foreach (var i in d)
            {
                if (true)
                {
                    string st1 = i.Key;
                    if (!c4.Contains(st1)) continue;
                    string st2;
                    string st3;
                    Dictionary<string, string> myd = (Dictionary<string, string>)i.Value;
                    foreach (var j in myd)
                    {
                        st2 = j.Key;
                        st3 = j.Value;
                        MyList4.Add(new card { Title = st1, ImagePath = new BitmapImage(new Uri("ms-appx:///" + "Assets/法师卡牌库/" + st1 + ".png")), Content = "类型：" + st2 + "\n稀有度：" + st3 });
                        MyList4.Add(new card { Title = st1, ImagePath = new BitmapImage(new Uri("ms-appx:///" + "Assets/法师卡牌库/" + st1 + ".png")), Content = "类型：" + st2 + "\n稀有度：" + st3 });
                    }
                }
            }
            return MyList4;
        }


        public ObservableCollection<card> Group5()
        {
            foreach (var i in d)
            {
                if (true)
                {
                    string st1 = i.Key;
                    if (!c5.Contains(st1)) continue;
                    string st2;
                    string st3;
                    Dictionary<string, string> myd = (Dictionary<string, string>)i.Value;
                    foreach (var j in myd)
                    {
                        st2 = j.Key;
                        st3 = j.Value;
                        MyList5.Add(new card { Title = st1, ImagePath = new BitmapImage(new Uri("ms-appx:///" + "Assets/法师卡牌库/" + st1 + ".png")), Content = "类型：" + st2 + "\n稀有度：" + st3 });
                        MyList5.Add(new card { Title = st1, ImagePath = new BitmapImage(new Uri("ms-appx:///" + "Assets/法师卡牌库/" + st1 + ".png")), Content = "类型：" + st2 + "\n稀有度：" + st3 });
                    }
                }
            }
            return MyList5;
        }

        public ObservableCollection<card> Group6()
        {
            foreach (var i in d)
            {
                if (true)
                {
                    string st1 = i.Key;
                    if (!c6.Contains(st1)) continue;
                    string st2;
                    string st3;
                    Dictionary<string, string> myd = (Dictionary<string, string>)i.Value;
                    foreach (var j in myd)
                    {
                        st2 = j.Key;
                        st3 = j.Value;
                        MyList6.Add(new card { Title = st1, ImagePath = new BitmapImage(new Uri("ms-appx:///" + "Assets/法师卡牌库/" + st1 + ".png")), Content = "类型：" + st2 + "\n稀有度：" + st3 });
                        MyList6.Add(new card { Title = st1, ImagePath = new BitmapImage(new Uri("ms-appx:///" + "Assets/法师卡牌库/" + st1 + ".png")), Content = "类型：" + st2 + "\n稀有度：" + st3 });
                    }
                }
            }
            return MyList6;
        }

        public ObservableCollection<card> Group7()
        {
            foreach (var i in d)
            {
                if (true)
                {
                    string st1 = i.Key;
                    if (!c7.Contains(st1)) continue;
                    string st2;
                    string st3;
                    Dictionary<string, string> myd = (Dictionary<string, string>)i.Value;
                    foreach (var j in myd)
                    {
                        st2 = j.Key;
                        st3 = j.Value;
                        MyList7.Add(new card { Title = st1, ImagePath = new BitmapImage(new Uri("ms-appx:///" + "Assets/法师卡牌库/" + st1 + ".png")), Content = "类型：" + st2 + "\n稀有度：" + st3 });
                        MyList7.Add(new card { Title = st1, ImagePath = new BitmapImage(new Uri("ms-appx:///" + "Assets/法师卡牌库/" + st1 + ".png")), Content = "类型：" + st2 + "\n稀有度：" + st3 });
                    }
                }
            }
            return MyList7;
        }
        public VModel()
        {
            mylist = new ObservableCollection<card>();
            mylist1 = new ObservableCollection<card>();
            mylist2 = new ObservableCollection<card>();
            mylist3 = new ObservableCollection<card>();
            mylist4 = new ObservableCollection<card>();
            mylist5 = new ObservableCollection<card>();
            mylist6 = new ObservableCollection<card>();
            mylist7 = new ObservableCollection<card>();
            selectedItemIndex = -1;
            c1 =new List<string> ()
            {
                    "奥术飞弹","奥术飞弹","变形术","变形术","狗头人地卜师","狗头人地卜师","古拉巴什狂暴者","古拉巴什狂暴者","寒冰箭","寒冰箭",
                    "火球术","火球术","竞技场主宰","竞技场主宰","镜像","镜像","烈焰风暴","烈焰风暴","魔爆术","魔爆术",
                    "森金持盾卫士","森金持盾卫士","食人魔法师","食人魔法师","水元素","水元素","酸性沼泽软泥怪","酸性沼泽软泥怪",
            };
            c2 = new List<string>()
            {
                     "奥术智慧","奥术智慧","变形术","变形术","冰枪术","冰枪术","大法师安东尼达斯","地精炎术士","地精炎术士","发条侏儒",
                     "发条侏儒","法力浮龙","法力浮龙","工匠镇技师","工匠镇技师","寒冰箭","寒冰箭","机械雪人","机械雪人","机械跃迁者",
                     "机械跃迁者","烈焰风暴","洛欧赛布.png","麦田傀儡","麦田傀儡","水元素","碎雪机器人","碎雪机器人","蜘蛛坦克","蜘蛛坦克",
                
            };
            c3 = new List<string>()
            {
                    "奥术智慧","奥术智慧","变形术","冰枪术","冰枪术","地精炎术士","地精炎术士","工匠镇技师","工匠镇技师","寒冰箭",
                    "寒冰箭","火球术","火球术","机械雪人","机械雪人","机械跃迁者","机械跃迁者","烈焰轰击","洛欧赛布","麦田傀儡",
                    "麦田傀儡","碎雪机器人","碎雪机器人","血法师萨尔诺斯","水元素","水元素","蜘蛛坦克","蜘蛛坦克",
            };
            c4 = new List<string>()
            {
                    "阿古斯防御者","阿古斯防御者","阿曼尼狂战士","阿曼尼狂战士","奥术飞弹","奥术智慧","碧蓝幼龙","变形术.","冰风雪人","冰风雪人",
                    "法力浮龙","法力浮龙","疯狂的炼金师","寒冰箭","寒冰箭","火球术","火球术","苦痛侍僧.","狂奔科多兽","麦田傀儡",
                    "麦田傀儡","破碎残阳祭司","日怒保卫者","银色侍从.png","水元素","水元素","银色侍从.png",
            };
            c5 = new List<string>()
            {
                    "阿曼尼狂战士","阿曼尼狂战士","奥术飞弹","奥术飞弹","暴怒的狼人","暴怒的狼人","碧蓝幼龙","碧蓝幼龙","法力浮龙","法力浮龙",
                    "飞刀杂耍者","飞刀杂耍者","寒冰箭","寒冰箭","麦田傀儡","麦田傀儡","破碎残阳祭司","破碎残阳祭司","银色侍从","银色侍从",
                    "战利品贮藏者","战利品贮藏者","银色指挥官","水元素","水元素","酸性沼泽软泥怪","烈日行者",
            };
            c6 = new List<string>()
            {
                    "奥术智慧","奥术智慧","变形术","大法师安东尼达斯","不稳定的传送门","不稳定的传送门","地精炎术士","地精炎术士","寒冰箭","寒冰箭",
                    "火球术","火球术","发条侏儒","发条侏儒","工匠镇技师","法力浮龙","法力浮龙","工匠镇技师","机械雪人","机械雪人",
                    "加兹鲁维","烈焰轰击","水元素","巫师学徒","水元素","水元素","血法师萨尔诺斯","酸性沼泽软泥怪","淤泥喷射者","淤泥喷射者",
                    "蜘蛛坦克","蜘蛛坦克"
            };
            c7 = new List<string>()
            {
                    "奥术智慧","奥术智慧","法力浮龙","法力浮龙","法术反制","法术反制","疯狂的科学家","疯狂的科学家","寒冰箭","寒冰箭",
                    "火球术","火球术","肯瑞托法师","肯瑞托法师","镜像实体","镜像实体","烈焰风暴","洛欧赛布","送葬者","送葬者",
                    "麦田傀儡","麦田傀儡","淤泥喷射者","淤泥喷射者","水元素","水元素","希尔瓦娜斯·风行者","复制","战利品贮藏者","战利品贮藏者",
            };
            d = new Dictionary<string, Dictionary<string, string>>()
            {
              {"奥术智慧",	new Dictionary <string,string>(){{"法术", "基础卡牌" }} },
              {"暴风雪",	new Dictionary<string,string>(){{"法术", "稀有卡牌" }} },
              {"变形术",	new Dictionary<string,string>(){{"法术", "基础卡牌" }} },
              {"冰枪术",	new Dictionary<string,string>(){{"法术", "普通卡牌" }} },
              {"冰锥术",	new Dictionary<string,string>(){{"法术", "普通卡牌" }} },
              {"法术反制",	new Dictionary<string,string>(){{"法术", "稀有卡牌" }} },
              {"寒冰护体",	new Dictionary<string,string>(){{"法术", "普通卡牌" }} },
              {"寒冰箭",	new Dictionary<string,string>(){{"法术", "基础卡牌" }} },
              {"寒冰屏障",	new Dictionary<string,string>(){{"法术", "史诗卡牌" }} },
              {"火球术",	new Dictionary<string,string>(){{"法术", "基础卡牌" }} },
              {"镜像",	new Dictionary<string,string>(){{"法术", "基础卡牌" }} },
              {"镜像实体",	new Dictionary<string,string>(){{"法术", "普通卡牌" }} },
              {"魔爆术",	new Dictionary<string,string>(){{"法术", "基础卡牌" }} },
              {"炎爆术",	new Dictionary<string,string>(){{"法术", "史诗卡牌" }} },
              {"蒸发",	new Dictionary<string,string>(){{"法术", "稀有卡牌" }} },
              {"大法师安东尼达斯",	new Dictionary<string,string>(){{"随从", "传说卡牌" }} },
              {"阿莱克丝塔萨",	new Dictionary<string,string>(){{"随从", "传说卡牌" }} },
              {"比斯巨兽",	new Dictionary<string,string>(){{"随从", "传说卡牌" }} },
              {"格尔宾·梅卡托克",	new Dictionary<string,string>(){{"随从", "传说卡牌" }} },
              {"格鲁尔",	new Dictionary<string,string>(){{"随从", "传说卡牌" }} },
              {"工匠大师欧沃斯巴克",	new Dictionary<string,string>(){{"随从", "传说卡牌" }} },
              {"哈里森·琼斯",	new Dictionary<string,string>(){{"随从", "传说卡牌" }} },
              {"黑骑士",	new Dictionary<string,string>(){{"随从", "传说卡牌" }} },
              {"火车王里诺艾",	new Dictionary<string,string>(){{"随从", "传说卡牌" }} },
              {"霍格",	new Dictionary<string,string>(){{"随从", "传说卡牌" }} },
              {"迦顿男爵",	new Dictionary<string,string>(){{"随从", "传说卡牌" }} },
              {"凯恩·血蹄",	new Dictionary<string,string>(){{"随从", "传说卡牌" }} },
              {"老瞎眼",	new Dictionary<string,string>(){{"随从", "传说卡牌" }} },
              {"玛里苟斯",	new Dictionary<string,string>(){{"随从", "传说卡牌" }} },
              {"米尔豪斯·法力风暴",	new Dictionary<string,string>(){{"随从", "传说卡牌" }} },
              {"穆克拉",	new Dictionary<string,string>(){{"随从", "传说卡牌" }} },
              {"纳特·帕格",	new Dictionary<string,string>(){{"随从", "传说卡牌" }} },
              {"诺兹多姆",	new Dictionary<string,string>(){{"随从", "传说卡牌" }} },
              {"死亡之翼",	new Dictionary<string,string>(){{"随从", "传说卡牌" }} },
              {"希尔瓦娜斯·风行者",	new Dictionary<string,string>(){{"随从", "传说卡牌" }} },
              {"血法师萨尔诺斯",	new Dictionary<string,string>(){{"随从", "传说卡牌" }} },
              {"炎魔之王拉格纳罗斯",	new Dictionary<string,string>(){{"法术", "传说卡牌" }} },
              {"伊利丹·怒风",	new Dictionary<string,string>(){{"随从", "传说卡牌" }} },
              {"伊瑟拉",	new Dictionary<string,string>(){{"随从", "传说卡牌" }} },
              {"游学者周卓",	new Dictionary<string,string>(){{"随从", "传说卡牌" }} },
              {"精英牛头人酋长",	new Dictionary<string,string>(){{"法术", "传说卡牌" }} },
              {"水元素",	new Dictionary<string,string>(){{"随从", "基础卡牌" }} },
              {"暗鳞先知",	new Dictionary<string,string>(){{"随从", "基础卡牌" }} },
              {"暗鳞治愈者",	new Dictionary<string,string>(){{"随从", "基础卡牌" }} },
              {"暴风城骑士",	new Dictionary<string,string>(){{"随从", "基础卡牌" }} },
              {"暴风城勇士",	new Dictionary<string,string>(){{"随从", "基础卡牌" }} },
              {"冰风雪人",	new Dictionary<string,string>(){{"随从", "基础卡牌" }} },
              {"藏宝海湾保镖",	new Dictionary<string,string>(){{"随从", "基础卡牌" }} },
              {"达拉然法师",	new Dictionary<string,string>(){{"随从", "基础卡牌" }} },
              {"大法师",	new Dictionary<string,string>(){{"随从", "基础卡牌" }} },
              {"工程师学徒",	new Dictionary<string,string>(){{"随从", "基础卡牌" }} },
              {"狗头人地卜师",	new Dictionary<string,string>(){{"随从", "基础卡牌" }} },
              {"古拉巴什狂暴者",	new Dictionary<string,string>(){{"随从", "基础卡牌" }} },
              {"机械幼龙技工",	new Dictionary<string,string>(){{"随从", "基础卡牌" }} },
              {"精灵弓箭手",	new Dictionary<string,string>(){{"随从", "基础卡牌" }} },
              {"竞技场主宰",	new Dictionary<string,string>(){{"随从", "基础卡牌" }} },
              {"蓝腮战士",	new Dictionary<string,string>(){{"随从", "基础卡牌" }} },
              {"狼骑兵",	new Dictionary<string,string>(){{"随从", "基础卡牌" }} },
              {"雷矛特种兵",	new Dictionary<string,string>(){{"随从", "基础卡牌" }} },
              {"鲁莽火箭兵",	new Dictionary<string,string>(){{"随从", "基础卡牌" }} },
              {"绿洲钳嘴龟",	new Dictionary<string,string>(){{"随从", "基础卡牌" }} },
              {"破碎残阳祭司",	new Dictionary<string,string>(){{"随从", "基础卡牌" }} },
              {"熔火恶犬",	new Dictionary<string,string>(){{"随从", "基础卡牌" }} },
              {"森金持盾卫士",	new Dictionary<string,string>(){{"随从", "基础卡牌" }} },
              {"闪金镇步兵",	new Dictionary<string,string>(){{"随从", "基础卡牌" }} },
              {"石拳食人魔",	new Dictionary<string,string>(){{"随从", "基础卡牌" }} },
              {"石牙野猪",	new Dictionary<string,string>(){{"随从", "基础卡牌" }} },
              {"食人魔法师",	new Dictionary<string,string>(){{"随从", "基础卡牌" }} },
              {"霜狼步兵",	new Dictionary<string,string>(){{"随从", "基础卡牌" }} },
              {"霜狼督军",	new Dictionary<string,string>(){{"随从", "基础卡牌" }} },
              {"酸性沼泽软泥怪",	new Dictionary<string,string>(){{"随从", "基础卡牌" }} },
              {"剃刀猎手",	new Dictionary<string,string>(){{"随从", "基础卡牌" }} },
              {"铁炉堡火枪手",	new Dictionary<string,string>(){{"随从", "基础卡牌" }} },
              {"铁鬃灰熊",	new Dictionary<string,string>(){{"随从", "基础卡牌" }} },
              {"团队领袖",	new Dictionary<string,string>(){{"随从", "基础卡牌" }} },
              {"巫医",	new Dictionary<string,string>(){{"随从", "基础卡牌" }} },
              {"血沼迅猛龙",	new Dictionary<string,string>(){{"随从", "基础卡牌" }} },
              {"岩浆暴怒者",	new Dictionary<string,string>(){{"随从", "基础卡牌" }} },
              {"夜刃刺客",	new Dictionary<string,string>(){{"随从", "基础卡牌" }} },
              {"鱼人猎潮者",	new Dictionary<string,string>(){{"随从", "基础卡牌" }} },
              {"鱼人袭击者",	new Dictionary<string,string>(){{"随从", "基础卡牌" }} },
              {"侏儒发明家",	new Dictionary<string,string>(){{"随从", "基础卡牌" }} },
              {"作战傀儡",	new Dictionary<string,string>(){{"随从", "基础卡牌" }} },
              {"巫师学徒",	new Dictionary<string,string>(){{"随从", "普通卡牌" }} },
              {"法力浮龙",	new Dictionary<string,string>(){{"随从", "普通卡牌" }} },
              {"阿曼尼狂战士",	new Dictionary<string,string>(){{"随从", "普通卡牌" }} },
              {"艾露恩的女祭司",	new Dictionary<string,string>(){{"随从", "普通卡牌" }} },
              {"白银之手骑士",	new Dictionary<string,string>(){{"随从", "普通卡牌" }} },
              {"暴怒的狼人",	new Dictionary<string,string>(){{"随从", "普通卡牌" }} },
              {"冰霜元素",	new Dictionary<string,string>(){{"随从", "普通卡牌" }} },
              {"持盾卫士",	new Dictionary<string,string>(){{"随从", "普通卡牌" }} },
              {"丛林猎豹",	new Dictionary<string,string>(){{"随从", "普通卡牌" }} },
              {"大地之环先知",	new Dictionary<string,string>(){{"随从", "普通卡牌" }} },
              {"恶毒铁匠",	new Dictionary<string,string>(){{"随从", "普通卡牌" }} },
              {"风怒鹰身人",	new Dictionary<string,string>(){{"随从", "普通卡牌" }} },
              {"风险投资公司雇佣兵",	new Dictionary<string,string>(){{"随从", "普通卡牌" }} },
              {"疯狂投弹者",	new Dictionary<string,string>(){{"随从", "普通卡牌" }} },
              {"腐肉食尸鬼",	new Dictionary<string,string>(){{"随从", "普通卡牌" }} },
              {"黑铁矮人",	new Dictionary<string,string>(){{"随从", "普通卡牌" }} },
              {"叫嚣的中士",	new Dictionary<string,string>(){{"随从", "普通卡牌" }} },
              {"荆棘谷猛虎",	new Dictionary<string,string>(){{"随从", "普通卡牌" }} },
              {"精灵龙",	new Dictionary<string,string>(){{"随从", "普通卡牌" }} },
              {"恐怖海盗",	new Dictionary<string,string>(){{"随从", "普通卡牌" }} },
              {"恐狼前锋",	new Dictionary<string,string>(){{"随从", "普通卡牌" }} },
              {"苦痛侍僧",	new Dictionary<string,string>(){{"随从", "普通卡牌" }} },
              {"狼人渗透者",	new Dictionary<string,string>(){{"随从", "普通卡牌" }} },
              {"麦田傀儡",	new Dictionary<string,string>(){{"随从", "普通卡牌" }} },
              {"魔古山守望者",	new Dictionary<string,string>(){{"随从", "普通卡牌" }} },
              {"南海船工",	new Dictionary<string,string>(){{"随从", "普通卡牌" }} },
              {"年迈的酒仙",	new Dictionary<string,string>(){{"随从", "普通卡牌" }} },
              {"牛头人战士",	new Dictionary<string,string>(){{"随从", "普通卡牌" }} },
              {"破法者",	new Dictionary<string,string>(){{"随从", "普通卡牌" }} },
              {"萨尔玛先知",	new Dictionary<string,string>(){{"随从", "普通卡牌" }} },
              {"铁喙猫头鹰",	new Dictionary<string,string>(){{"随从", "普通卡牌" }} },
              {"小精灵",	new Dictionary<string,string>(){{"随从", "普通卡牌" }} },
              {"血帆袭击者",	new Dictionary<string,string>(){{"随从", "普通卡牌" }} },
              {"血色十字军战士",	new Dictionary<string,string>(){{"随从", "普通卡牌" }} },
              {"银色侍从",	new Dictionary<string,string>(){{"随从", "普通卡牌" }} },
              {"银月城卫兵",	new Dictionary<string,string>(){{"随从", "普通卡牌" }} },
              {"幼龙鹰",	new Dictionary<string,string>(){{"随从", "普通卡牌" }} },
              {"战利品贮藏者",	new Dictionary<string,string>(){{"随从", "普通卡牌" }} },
              {"沼泽爬行者",	new Dictionary<string,string>(){{"随从", "普通卡牌" }} },
              {"诅咒教派领袖",	new Dictionary<string,string>(){{"随从", "普通卡牌" }} },
              {"船长的鹦鹉",	new Dictionary<string,string>(){{"随从", "史诗卡牌" }} },
              {"海巨人",	new Dictionary<string,string>(){{"随从", "史诗卡牌" }} },
              {"末日预言者",	new Dictionary<string,string>(){{"随从", "史诗卡牌" }} },
              {"南海船长",	new Dictionary<string,string>(){{"随从", "史诗卡牌" }} },
              {"熔核巨人",	new Dictionary<string,string>(){{"随从", "史诗卡牌" }} },
              {"山岭巨人",	new Dictionary<string,string>(){{"随从", "史诗卡牌" }} },
              {"王牌猎人",	new Dictionary<string,string>(){{"随从", "史诗卡牌" }} },
              {"无面操纵者",	new Dictionary<string,string>(){{"随从", "史诗卡牌" }} },
              {"血骑士",	new Dictionary<string,string>(){{"随从", "史诗卡牌" }} },
              {"鱼人领军",	new Dictionary<string,string>(){{"随从", "史诗卡牌" }} },
              {"鱼人杀手蟹",	new Dictionary<string,string>(){{"随从", "史诗卡牌" }} },
              {"肯瑞托法师",	new Dictionary<string,string>(){{"随从", "稀有卡牌" }} },
              {"虚灵奥术师",	new Dictionary<string,string>(){{"随从", "稀有卡牌" }} },
              {"阿古斯防御者",	new Dictionary<string,string>(){{"随从", "稀有卡牌" }} },
              {"奥秘守护者",	new Dictionary<string,string>(){{"随从", "稀有卡牌" }} },
              {"奥术傀儡",	new Dictionary<string,string>(){{"随从", "稀有卡牌" }} },
              {"报警机器人",	new Dictionary<string,string>(){{"随从", "稀有卡牌" }} },
              {"碧蓝幼龙",	new Dictionary<string,string>(){{"随从", "稀有卡牌" }} },
              {"帝王眼镜蛇",	new Dictionary<string,string>(){{"随从", "稀有卡牌" }} },
              {"法力怨魂",	new Dictionary<string,string>(){{"随从", "稀有卡牌" }} },
              {"飞刀杂耍者",	new Dictionary<string,string>(){{"随从", "稀有卡牌" }} },
              {"愤怒的小鸡",	new Dictionary<string,string>(){{"随从", "稀有卡牌" }} },
              {"疯狂的炼金师",	new Dictionary<string,string>(){{"随从", "稀有卡牌" }} },
              {"寒光先知",	new Dictionary<string,string>(){{"随从", "稀有卡牌" }} },
              {"加基森拍卖师",	new Dictionary<string,string>(){{"随从", "稀有卡牌" }} },
              {"精神控制技师",	new Dictionary<string,string>(){{"随从", "稀有卡牌" }} },
              {"狂奔科多兽",	new Dictionary<string,string>(){{"随从", "稀有卡牌" }} },
              {"拉文霍德刺客",	new Dictionary<string,string>(){{"随从", "稀有卡牌" }} },
              {"烈日行者",	new Dictionary<string,string>(){{"随从", "稀有卡牌" }} },
              {"魔瘾者",	new Dictionary<string,string>(){{"随从", "稀有卡牌" }} },
              {"暮光幼龙",	new Dictionary<string,string>(){{"随从", "稀有卡牌" }} },
              {"年迈的法师",	new Dictionary<string,string>(){{"随从", "稀有卡牌" }} },
              {"年轻的女祭司",	new Dictionary<string,string>(){{"随从", "稀有卡牌" }} },
              {"任务达人",	new Dictionary<string,string>(){{"随从", "稀有卡牌" }} },
              {"上古看守者",	new Dictionary<string,string>(){{"随从", "稀有卡牌" }} },
              {"圣光护卫者",	new Dictionary<string,string>(){{"随从", "稀有卡牌" }} },
              {"小个子召唤师",	new Dictionary<string,string>(){{"随从", "稀有卡牌" }} },
              {"小鬼召唤师",	new Dictionary<string,string>(){{"随从", "稀有卡牌" }} },
              {"血帆海盗",	new Dictionary<string,string>(){{"随从", "稀有卡牌" }} }, 
            };
        }

        public int SelectedItemIndex
        {
            get
            {
                return selectedItemIndex;
            }
            set
            {
                selectedItemIndex = value;
                NotifyPropertyChanged("SelectedItemIndex");
            }
        }

        public ObservableCollection<card> MyList
        {
            get
            {
                return mylist;
            }
        }
        public ObservableCollection<card> MyList1
        {
            get
            {
                return mylist1;
            }
        }
        public ObservableCollection<card> MyList2
        {
            get
            {
                return mylist2;
            }
        }
        public ObservableCollection<card> MyList3
        {
            get
            {
                return mylist3;
            }
        }
        public ObservableCollection<card> MyList4
        {
            get
            {
                return mylist4;
            }
        }
        public ObservableCollection<card> MyList5
        {
            get
            {
                return mylist5;
            }
        }
        public ObservableCollection<card> MyList6
        {
            get
            {
                return mylist6;
            }
        }
        public ObservableCollection<card> MyList7
        {
            get
            {
                return mylist7;
            }
        }
        //注册事件 PropertyChangedEventHandler
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string str)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(str));
            }
        }
        // 实现Search功能
        public void Search(string searchTerm)
        {
            int selectedItemIndex = -1;
            for (int i = 0; i < mylist.Count; i++)
            {
                //从title里面匹配seachTerm
                if (mylist[i].Title.ToLower().Contains(searchTerm.ToLower()))
                {
                    selectedItemIndex = i;
                }
            }
            SelectedItemIndex = selectedItemIndex;
        }


    


    }
}
