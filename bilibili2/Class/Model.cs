﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;

namespace bilibili2
{
    //Banner
    public class BannerModel
    {
        public int results { get; set; }
        public object data { get; set; }
        public string title { get; set; }
        public int type { get; set; }
        public string image { get; set; }
        public string value { get; set; }

    }
    //视频详细信息
    public class VideoInfoModel
    {
        public int code { get; set; }
        public string error { get; set; }
        public object list { get; set; }
        public string pic { get; set; }
        public string title { get; set; }
        public string play { get; set; }
        public string typename { get; set; }
        public string author { get; set; }
        public string video_review { get; set; }
        public string description { get; set; }
        public string mid { get; set; }
        public string aid { get; set; }
        public string created_at { get; set; }
        public string favorites { get; set; }
        public string face { get; set; }

        public string coins { get; set; }
        public string page { get; set; }
        public string part { get; set; }
        public string cid { get; set; }
        public string tag { get; set; }

        public string Play
        {
            get
            {
                if (Convert.ToInt32(play) > 10000)
                {
                    double d = (double)Convert.ToDouble(play) / 10000;
                    return d.ToString("0.0") + "万";
                }
                else
                {
                    return play;
                }
            }
        }
        public string Video_review
        {
            get
            {
                if (Convert.ToInt32(video_review) > 10000)
                {
                    double d = (double)Convert.ToDouble(video_review) / 10000;
                    return d.ToString("0.0") + "万";
                }
                else
                {
                    return video_review;
                }
            }
        }
        public string Favorites
        {
            get
            {
                if (Convert.ToInt32(favorites) > 10000)
                {
                    double d = (double)Convert.ToDouble(favorites) / 10000;
                    return d.ToString("0.0") + "万";
                }
                else
                {
                    return favorites;
                }
            }
        }
        public string Coins
        {
            get
            {
                if (Convert.ToInt32(coins) > 10000)
                {
                    double d = (double)Convert.ToDouble(coins) / 10000;
                    return d.ToString("0.0") + "万";
                }
                else
                {
                    return coins;
                }
            }
        }

        public string Created_at {
            get
            {
                DateTime dt = Convert.ToDateTime(created_at);
                if (dt.Date == DateTime.Now.Date)
                {
                    TimeSpan ts = DateTime.Now - dt;
                    return ts.Hours + "小时前";
                }
                else
                {
                    return created_at;
                }
            }
        }

    }
    //视频信息
    public class VideoModel
    {
        public int code { get; set; }
        public object data { get; set; }

        //视频信息
        public string aid { get; set; }
        public string copyright { get; set; }
        public string pic { get; set; }
        public string title { get; set; }
        public string pubdate { get; set; }
        public string desc { get; set; }
        //UP信息
        public object owner { get; set; }
        public string mid { get; set; }
        public string name { get; set; }
        public string face { get; set; }
        //视频数据
        public object stat { get; set; }
        public string view { get; set; }
        public string danmaku { get; set; }
        public string reply { get; set; }
        public string favorite { get; set; }
        public string coin { get; set; }
        public string share { get; set; }
        //TAG
        public object tags { get; set; }
        //视频P
        public object pages { get; set; }
        public string cid { get; set; }
        public string page { get; set; }
        public string from { get; set; }
        public string part { get; set; }
        public string rich_vid { get; set; }
        public string vid { get; set; }
        //番剧信息
        public object season { get; set; }
        public string season_id { get; set; }
        public string cover { get; set; }
        public int is_finish { get; set; }
        public int weekday { get; set; }
        public int total_count { get; set; }
        public string BanText
        {
            get
            {
                if (is_finish == 1)
                {
                    return string.Format("已完结,共{0}话", total_count);
                }
                else
                {
                    string we = string.Empty;
                    switch (weekday)
                    {
                        case 1:
                            we = "一";
                            break;
                        case 2:
                            we = "二";
                            break;
                        case 3:
                            we = "三";
                            break;
                        case 4:
                            we = "四";
                            break;
                        case 5:
                            we = "五";
                            break;
                        case 6:
                            we = "六";
                            break;
                        case 7:
                            we = "日";
                            break;
                        default:
                            break;
                    }
                    return string.Format("连载中,每周{0}更新", we);
                }
            }
        }
        //充电信息
        public object elec { get; set; }
        public bool show { get; set; }
        public int total { get; set; }
        public int count { get; set; }
        public object list { get; set; }
        public string pay_mid { get; set; }
        public int rank { get; set; }
        public string uname { get; set; }
        public string avatar { get; set; }
        public string message { get; set; }
        public int msg_deleted { get; set; }
        //以下两项用于本地视频
        public bool inLocal { get; set; }
        public string path { get; set; }
        public bool IsOld { get; set; }
        public SolidColorBrush forColor { get; set; }
        public Visibility IsDowned { get; set; }

        //视频关注信息
        public object req_user { get; set; }
        public int attention { get; set; }//关注Up主,-999为关注,1已关注
        //public int favorite { get; set; }//是否已经收藏，0为未收藏，1为已经收藏
        public object relates { get; set; }
        public string Play
        {
            get
            {
                if (Convert.ToInt32(view) > 10000)
                {
                    double d = (double)Convert.ToDouble(view) / 10000;
                    return d.ToString("0.0") + "万";
                }
                else
                {
                    return view;
                }
            }
        }
        public string Video_review
        {
            get
            {
                if (Convert.ToInt32(danmaku) > 10000)
                {
                    double d = (double)Convert.ToDouble(danmaku) / 10000;
                    return d.ToString("0.0") + "万";
                }
                else
                {
                    return danmaku;
                }
            }
        }
        public string Favorites
        {
            get
            {
                if (Convert.ToInt32(favorite) > 10000)
                {
                    double d = (double)Convert.ToDouble(favorite) / 10000;
                    return d.ToString("0.0") + "万";
                }
                else
                {
                    return favorite;
                }
            }
        }
        public string Coins
        {
            get
            {
                if (Convert.ToInt32(coin) > 10000)
                {
                    double d = (double)Convert.ToDouble(coin) / 10000;
                    return d.ToString("0.0") + "万";
                }
                else
                {
                    return coin;
                }
            }
        }

        public string Created_at
        {
            get
            {
                DateTime dtStart = new DateTime(1970, 1, 1, 8, 0, 0);
                long lTime = long.Parse(pubdate + "0000000");
                //long lTime = long.Parse(textBox1.Text);
                TimeSpan toNow = new TimeSpan(lTime);

                DateTime dt = dtStart.Add(toNow);
                if (dt.Date == DateTime.Now.Date)
                {
                    TimeSpan ts = DateTime.Now - dt;
                    return ts.Hours + "小时前";
                }
                else
                {
                    return dt.ToString();
                }
            }
        }


        public MovieModel movie { get; set; }
       

    }
    public class VideoModelOld
    {
        public int code { get; set; }
        public object data { get; set; }

        public string typename { get; set; }
        public string arctype { get; set; }
        public string play { get; set; }
        public string review { get; set; }
        public string video_review { get; set; }
        public string favorites { get; set; }
        public string title { get; set; }
        public int allow_bp { get; set; }
        public int allow_feed { get; set; }
        public int allow_download { get; set; }
        public string description { get; set; }
        public string tag { get; set; }
        public string pic { get; set; }
        public string author { get; set; }
        public string mid { get; set; }
        public string face { get; set; }
        public int pages { get; set; }
        //TAG
        public string instant_server { get; set; }
        //视频P
        public long created { get; set; }
        public string created_at { get; set; }
        public int credit { get; set; }
        public string coins { get; set; }
        public string spid { get; set; }

        public VideoModelOld bangumi { get; set; }
        public string bangumi_id { get; set; }
        public string season_id { get; set; }

        public List<VideoModelOld> list { get; set; }
        public int page { get; set; }
        public string type { get; set; }
        public string part { get; set; }
      public string cid { get; set; }
        public bool has_alias { get; set; }
      


    }
    public class MovieModel
    {
        public int movie_status { get; set; }//1为收费，2为免费
        public MovieModel pay_user { get; set; }
        public int status { get; set; }//0为未付费
        public MovieModel payment { get; set; }
        public string pay_begin_time { get; set; }
        public decimal price { get; set; }
        public string product_id { get; set; }
        public MovieModel season { get; set; }

        public List<ActorModel> actor { get; set; }
       public string actors
        {
            get
            {
                if (actor.Count!=0)
                {
                    return actor[0].actor;
                }
                else
                {
                    return "";
                }
            }
        }




        public List<TagModel> tags { get; set; }
        public string tag
        {
            get
            {
                string str = "";
                foreach (var item in tags)
                {
                    str += item.tag_name + "、";
                }
                if (str.Length!=0)
                {
                    str= str.Remove(str.Length-1);
                }
                return str;
            }
        }

        public string area { get; set; }
        public string cover { get; set; }
        public string pub_time { get; set; }
        public string time
        {
            get
            {
                DateTime dt = Convert.ToDateTime(pub_time);
                return dt.ToString("yyyy-MM-dd"); 
            }
        }

        public string title { get; set; }
        public string total_duration { get; set; }
        public MovieModel activity { get; set; }
        public int activity_id { get; set; }
        public string link { get; set; }
        public string script_src { get; set; }
    }

    public class ActorModel
    {
        public string actor { get; set; }
        public int actor_id { get; set; }
    }

    //评论
    public class CommentModel
    {

        public object data { get; set; }
        public object replies { get; set; }
        public object member { get; set; }
        public object content { get; set; }
        public object level_info { get; set; }
        public string avatar { get; set; }
        public string uname { get; set; }
        public string floor { get; set; }
        public string rpid { get; set; }
        public long ctime { set; get; }
        public int plat { get; set; }
        public string Plat
        {
            get
            {
                switch (plat)
                {
                    case 2:
                        return "来自 Android";
                    case 3:
                        return "来自 IOS";
                    case 4:
                        return "来自 WindowsPhone";
                    case 6:
                        return "来自 Windows";
                    default:
                        return "";
                }
            }
        }
        public string mid { get; set; }
        public string time
        {
            get
            {
                //DateTime dtStart = new DateTime(1970, 1, 1);
                //long lTime = long.Parse(ctime + "0000000");
                ////long lTime = long.Parse(textBox1.Text);
                //TimeSpan toNow = new TimeSpan(lTime);
                //return dtStart.Add(toNow).ToLocalTime().ToString();

                DateTime dtStart = new DateTime(1970, 1, 1);
                long lTime = long.Parse(ctime + "0000000");
                //long lTime = long.Parse(textBox1.Text);
                TimeSpan toNow = TimeSpan.FromSeconds(ctime);
                DateTime dt = dtStart.Add(toNow).ToLocalTime();
                TimeSpan span = DateTime.Now - dt;
                if (span.TotalDays > 7)
                {
                    return dt.ToString("MM-dd");
                }
                else
                if (span.TotalDays > 1)
                {
                    return string.Format("{0}天前", (int)Math.Floor(span.TotalDays));
                }
                else
                if (span.TotalHours > 1)
                {
                    return string.Format("{0}小时前", (int)Math.Floor(span.TotalHours));
                }
                else
                if (span.TotalMinutes > 1)
                {
                    return string.Format("{0}分钟前", (int)Math.Floor(span.TotalMinutes));
                }
                else
                if (span.TotalSeconds >= 1)
                {
                    return string.Format("{0}秒前", (int)Math.Floor(span.TotalSeconds));
                }
                else
                {
                    return "1秒前";
                }


            }
        }
        public string rcount { get; set; }
        public string like { get; set; }
        public string message { get; set; }
        public int current_level { get; set; }
        public int action { get; set; }
        public string Action {
            get {
                if (action==0)
                {
                    return "赞同";
                }
                else
                {
                    return "取消赞";
                }
            } }

        public string LV
        {
            get
            {
                switch (current_level)
                {
                    case 0:
                        return "ms-appx:///Assets/MiniIcon/ic_lv0_large.png";
                    case 1:
                        return "ms-appx:///Assets/MiniIcon/ic_lv1_large.png";
                    case 2:
                        return "ms-appx:///Assets/MiniIcon/ic_lv2_large.png";
                    case 3:
                        return "ms-appx:///Assets/MiniIcon/ic_lv3_large.png";
                    case 4:
                        return "ms-appx:///Assets/MiniIcon/ic_lv4_large.png";
                    case 5:
                        return "ms-appx:///Assets/MiniIcon/ic_lv5_large.png";
                    case 6:
                        return "ms-appx:///Assets/MiniIcon/ic_lv6_large.png";
                    default:
                        return "";
                }
            }
        }
        public RichTextBlock text
        {
            get
            {
                if (message != null)
                {
                    string input = message;
                    input = input.Replace("\r\n", "<LineBreak/>");
                    input = input.Replace("\n", "<LineBreak/>");
                    MatchCollection mc = Regex.Matches(input, @"\[(.*?)\]");
                    foreach (Match item in mc)
                    {

                        input = input.Replace(item.Groups[0].Value, string.Format(@"<InlineUIContainer><Border><Image Source=""{0}"" Width=""36"" Height=""36""/></Border></InlineUIContainer>", ApiHelper.emojis.First(x => x.name == item.Groups[0].Value).url));
                    }

                    //生成xaml
                    var xaml = string.Format(@"<RichTextBlock HorizontalAlignment=""Stretch"" TextWrapping=""Wrap"" Margin=""5"" xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
                                            xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml"" xmlns:d=""http://schemas.microsoft.com/expression/blend/2008""
    xmlns:mc = ""http://schemas.openxmlformats.org/markup-compatibility/2006"" >
                                          <Paragraph>{0}</Paragraph>
                                      </RichTextBlock>", input);
                    var p = (RichTextBlock)XamlReader.Load(xaml);
                    return p;
                }
                else
                {
                    return null;
                }
            }

        }
    }
    //视频相关
    public class RecommendModel
    {
        public object owner { get; set; }
        public object stat { get; set; }

        public string title { get; set; }
        public string aid { get; set; }
        public string pic { get; set; }
        public string view { get; set; }
        public string danmaku { get; set; }
        public string name { get; set; }

    }
    //这个Model用来保存登录请求的access_key
    public class LoginModel
    {
        private string _access_key;
        public string access_key
        {
            get { return _access_key; }
            set { _access_key = value; }
        }
        public string mid { get; set; }
        public int code { get; set; }
        public string expires
        {
            get; set;
        }
    }
    //用户信息
    public class GetLoginInfoModel
    {
        public GetLoginInfoModel data { get; set; }
        public GetLoginInfoModel card { get; set; }


        public string mid { get; set; }//ID
        public string name { get; set; }//昵称
        public string sex { get; set; }//性别
        public string coins { get; set; }//硬币
        public string face { get; set; }//头像
        public bool approve { get; set; }
        public int rank { get; set; }//用户级别
        //public GetLoginInfoModel data { get; set; }
        public string RankStr
        {
            get
            {
                switch (rank)
                {
                    case 0:
                        return "普通用户";
                    case 5000:
                        return "注册会员";
                    case 10000:
                        return "正式会员";
                    case 20000:
                        return "字幕君";
                    case 25000:
                        return "VIP用户";
                    case 30000:
                        return "职人";
                    case 32000:
                        return "站长大人";
                    default:
                        return "蜜汁等级";
                }
            }
        }

        public string birthday { get; set; }//生日
        public long regtime { get; set; }//注册时间
        public string Regtime
        {
            get
            {
                DateTime dtStart = new DateTime(1970, 1, 1);
                long lTime = long.Parse(regtime + "0000000");
                TimeSpan toNow = new TimeSpan(lTime);
                return dtStart.Add(toNow).ToString("d");
            }
        }//转换后注册时间

        public string sign { get; set; }//个性签名
        public int fans { get; set; }//粉丝
        public string attention { get; set; }//关注

        public GetLoginInfoModel level_info { get; set; }//等级信息
        public int current_min { get; set; }
        public int current_exp { get; set; }
        public string next_exp { get; set; }

        public List<string> attentions { get; set; }
        //public string current_level_string { get { return "LV" + current_level; } }//等级
        public int current_level { get; set; }
        public string place { get; set; }//地址
        public string toutu { get; set; }

        public GetLoginInfoModel vip { get; set; }
        public int vipType { get; set; }//1大会员
        public int vipStatus { get; set; }//1为
        public string vipDueDate { get; set; }//VIP过期时间
        public string accessStatus { get; set; }//0为正在使用
        public string vipSurplusMsec { get; set; }//VIP剩余毫秒？为毛用毫秒- -
        public GetLoginInfoModel official_verify { get; set; }//认证
        public int type { get; set; }
        public string desc { get; set; }
    }

    public class UserInfoModel
    {
        public string mid { get; set; }
        public string uname { get; set; }
        public string face { get; set; }
        public string s_face { get; set; }
        public int rank { get; set; }
        public string scores { get; set; }//?
        public string coins { get; set; }
        public int sex { get; set; }
        public string maxstow { get; set; }
        public string sign { get; set; }
        public string jointime { get; set; }
        public int spacesta { get; set; }
        public List<string> attentions { get; set; }
        public int identification { get; set; }
        public UserInfoModel level_info
        {
            get;set;
        }
        public int current_level { get; set; }
        public int current_min { get; set; }
        public int current_exp { get; set; }
        public string next_exp { get; set; }

        public int security_level { get; set; }
        public string birthday { get; set; }
        public int mobile_verified { get; set; }
        public string telephone { get; set; }

        public UserInfoModel vip { get; set; }
        public int vipType { get; set; }//1大会员
        public int vipStatus { get; set; }//1为
        public string vipDueDate { get; set; }//VIP过期时间
        public string accessStatus { get; set; }//0为正在使用
        public string vipSurplusMsec { get; set; }//VIP剩余毫秒？为毛用毫秒- -
        public UserInfoModel official_verify { get; set; }//认证
        public int type { get; set; }
        public string desc { get; set; }
        public string RankStr
        {
            get
            {
                switch (rank)
                {
                    case 0:
                        return "普通用户";
                    case 5000:
                        return "注册会员";
                    case 10000:
                        return "正式会员";
                    case 20000:
                        return "字幕君";
                    case 25000:
                        return "VIP用户";
                    case 30000:
                        return "职人";
                    case 32000:
                        return "站长大人";
                    default:
                        return "蜜汁等级";
                }
            }
        }
    }


    public class GetFavouriteBoxsVideoModel
    {
        //Josn：http://space.bilibili.com/ajax/fav/getList?mid=用户ID&pagesize=30&fid=收藏夹编号
        //第一层
        public bool status { get; set; }//标题
        public object data { get; set; }//包含第二层
                                        //第二层
        public int pages { get; set; }//页数
        public int count { get; set; }//数量
        public object vlist { get; set; }//包含第三层
                                         //第三层
        public string aid { get; set; }//AID
        public string typename { get; set; }//类型
        public string title { get; set; }//标题
        public string author { get; set; }//作者
        public string pic { get; set; }//封面
        public string fav_create_at { get; set; }
    }
    public class GetUserFovBox
    {
        //Josn：http://space.bilibili.com/ajax/fav/getBoxList?mid=XXXXX
        //第一层
        public bool status { get; set; }//状态
        public object data { get; set; }//数据，包含第二层
                                        //第二层
        public object list { get; set; }//结果，包含第三层
                                        //第三层
        public string fav_box { get; set; }//收藏夹ID，重要！！！
        public int count { get; set; }//数量
        public string Count
        {
            get
            {
                return count + "个视频";
            }
        }
        public string name { get; set; }//标题
        public long ctime { get; set; }//未转换创建时间
        public int max_count { get; set; }//最大数量

    }
    public class GetUserAttention
    {
        //Josn：http://space.bilibili.com/ajax/friend/GetAttentionList?mid=XXXX&pagesize=999
        //第一层
        public bool status { get; set; }//状态
        public object data { get; set; }//数据，包含第二层
                                        //第二层
        public object list { get; set; }//结果，包含第三层
                                        //第三层
        public string record_id { get; set; }//记录ID，重要！！！
        public string uname { get; set; }//昵称
        public string face { get; set; }//头像
        public string fid { get; set; }//FID
        public long addtime { get; set; }//记录时间
        public int pages { get; set; }

    }
    public class GetUserSubmit
    {
        //Josn：http://space.bilibili.com/ajax/friend/GetAttentionList?mid=XXXX&pagesize=999
        //第一层
        public bool status { get; set; }//状态
        public object data { get; set; }//数据，包含第二层
                                        //第二层
        public object vlist { get; set; }//结果，包含第三层
        public object list { get; set; }//结果，包含第三层
                                        //第三层
        public string aid { get; set; }//视频ID
        public string title { get; set; }//标题
        public string pic { get; set; }//图片
        public string video_review { get; set; }//弹幕
        public string play { get; set; }//播放
        public string created { get; set; }//上传时间
        public string length { get; set; }//长度
        public string description { get; set; }
        public string uname { get; set; }
        public int count { get; set; }
        public int pages { get; set; }
    }
    public class GetHistoryModel
    {
        //必须有登录Cookie
        //Josn：http://api.bilibili.com/x/history?jsonp=jsonp&ps=20&pn=1
        public int code { get; set; }
        public object data { get; set; }
        public string aid { get; set; }
        public string cover { get; set; }
        public string pic { get; set; }
        public string title { get; set; }
        public long view_at { get; set; }
        public string View_at
        {
            get
            {
                DateTime dtStart = new DateTime(1970, 1, 1);
                long lTime = long.Parse(view_at + "0000000");
                TimeSpan toNow = new TimeSpan(lTime);
                return dtStart.Add(toNow).ToString("d");
            }
        }//转
        public string tname { get; set; }
    }
    public class GetAttentionLive
    {
        public int code { get; set; }
        public string message { get; set; }

        public object data { get; set; }
        public int page { get; set; }
        public int pagesize { get; set; }

        public object list { get; set; }
        public string name { get; set; }
        public string face { get; set; }
        public string roomid { get; set; }
        public int live_status { get; set; }//0为未开播
        public string areaName { get; set; }

        public string state
        {
            get
            {
                if (live_status == 1)
                {
                    return "正在直播";
                }
                else
                {
                    return "未开播";
                }
            }
        }
    }
    //首页信息
    public class InfoModel
    {
        public object list { get; set; }
        public object rank { get; set; }
        public string pic { get; set; }
        
        public string title { get; set; }
        public string play { get; set; }
        public string author { get; set; }
        public string video_review { get; set; }
        public string description { get; set; }
        public string mid { get; set; }
        public string aid { get; set; }
        public int num { get; set; }
        public SolidColorBrush forColor{ get; set; }

        //用于直播
        public object data { get; set; }
        public string room_id { get; set; }
        public string online { get; set; }
        public string uname { get; set; }
        public string cover { get; set; }
        public string face { get; set; }
        public string roomid { get; set; }
    }

    public class HomeHotModel
    {
        public int code { get; set; }
        public List<HomeHotModel> data { get; set; }
        public string title { get; set; }
        public List<HomeHotModel> body { get; set; }
        public string cover { get; set; }
        public string uri { get; set; }
        public string param { get; set; }
        public string play { get; set; }
        public string danmaku { get; set; }
    }

    //热门搜索
    public class HotModel
    {
        public object list { get; set; }
        public string keyword { get; set; }
        public string status { get; set; }
    }
    //用户追番
    public class GetUserBangumi
    {
        //Josn：http://space.bilibili.com/ajax/Bangumi/getList?mid=XXX&pagesize=9999
        //第一层
        public bool status { get; set; }//状态
        public object data { get; set; }//数据，包含第二层
                                        //第二层
        public int count { get; set; }//总数量
        public object result { get; set; }//结果，包含第三层
                                          //第三层
        public string season_id { get; set; }//专题ID，重要！！！
        public string title { get; set; }//标题
        public int is_finish { get; set; }//是否完结，0为连载，1为完结
        public string favorites { get; set; }//有多少人关注
        public int newest_ep_index { get; set; }//最新话
        public int total_count { get; set; }//一共多少话
        public string NewOver
        {
            get
            {
                if (is_finish == 0)
                {
                    return "更新至第" + newest_ep_index + "话";
                }
                else
                {
                    return total_count + "话全";
                }
            }
        }
        public string cover { get; set; }//封面
        public string brief { get; set; }//简介
        public int pages { get; set; }
    }
    //用户动态
    public class GetAttentionUpdate
    {
        //必须有登录Cookie
        //Josn：http://api.bilibili.com/x/feed/pull?jsonp=jsonp&ps=20&type=1&pn=1
        //第一层
        public int code { get; set; }//状态，0为正常
        public object data { get; set; }//数据，包含第二层
                                       
        public List<GetAttentionUpdate> feeds { get; set; }

        public GetAttentionUpdate page { get; set; }
        public int count { get; set; }
        public int num { get; set; }
        public int size { get; set; }


        public string id { get; set; }//视频ID
        public string src_id { get; set; }//作者信息，包含第四层
        public string add_id { get; set; }//视频信息，包含第四层
        public int type { get; set; }
        public string mcid { get; set; }
        public GetAttentionUpdate source { get; set; }
        public string mid { get; set; }
        public string uname { get; set; }
        public string sex { get; set; }
        public string avatar { get; set; }
        public string sign { get; set; }
        public GetAttentionUpdate new_ep { get; set; }
        public string av_id { get; set; }
        public string index { get; set; }

        public GetAttentionUpdate addition { get; set; }
        public string aid { get; set; }
        public string title { get; set; }//标题
        public string typename { get; set; }//播放数
        public int typeid { get; set; }//播放数

        public string play { get; set; }//弹幕数
        public string video_review { get; set; }//上传时间
        public string pic { get; set; }//封面
        public long ctime { get; set; }

        public GetAttentionUpdate content { get; set; }
        

        public string Create
        {
            get
            {
                DateTime dtStart = new DateTime(1970, 1, 1);
                //long lTime = long.Parse(ctime + "000");
                //long lTime = long.Parse(textBox1.Text);
                TimeSpan toNow =TimeSpan.FromSeconds(ctime);
                DateTime dt = dtStart.Add(toNow).ToLocalTime();
                TimeSpan span = DateTime.Now - dt;
                if (span.TotalDays > 7)
                {
                    return dt.ToString("MM-dd");
                }
                else
                if (span.TotalDays > 1)
                {
                    return string.Format("{0}天前", (int)Math.Floor(span.TotalDays));
                }
                else
                if (span.TotalHours > 1)
                {
                    return string.Format("{0}小时前", (int)Math.Floor(span.TotalHours));
                }
                else
                if (span.TotalMinutes > 1)
                {
                    return string.Format("{0}分钟前", (int)Math.Floor(span.TotalMinutes));
                }
                else
                if (span.TotalSeconds >= 1)
                {
                    return string.Format("{0}秒前", (int)Math.Floor(span.TotalSeconds));
                }
                else
                {
                    return "1秒前";
                }
            }
        }

    }
    //话题
    public class TopicModel
    {
        public int code { get; set; }
        public List<TopicModel> list { get; set; }
        public string title { get; set; }
        public string cover { get; set; }
        public string link { get; set; }
    }
    //排行
    public class RankModel
    {
        public object hot_original { get; set; }
        public object list { get; set; }
        public string pic { get; set; }
        public string title { get; set; }
        public string play { get; set; }
        public string author { get; set; }
        public string video_review { get; set; }
        public string description { get; set; }
        public string mid { get; set; }
        public string aid { get; set; }
        public int num { get; set; }
    }
    //番剧更新表
    public class BangumiTimeLineModel
    {
        public object list { get; set; }
        public string bgmcount { get; set; }
        public string cover { get; set; }
        public string lastupdate_at { get; set; }
        public string title { get; set; }
        public string square_cover { get; set; }
        public int weekday { get; set; }
        public string spid { get; set; }
        public string season_id { get; set; }
    }
    //番剧索引
    public class TagModel
    {
        public object result { get; set; }
        public string cover { get; set; }
        public int index { get; set; }
        public int tag_id { get; set; }
        public string tag_name { get; set; }
    }
    //番剧信息
    public class BangumiInfoModel:INotifyPropertyChanged
    {
        public int code { get; set; }
        public string message { get; set; }
        public object result { get; set; }

        public string alias { get; set; }//别名
        public string area { get; set; }//地区
        public string bangumi_title { get; set; }//番剧名。与season_title不同
        public string season_title { get; set; }//专题名
        public string title { get; set; }
        public string evaluate { get; set; }//介绍
        public int favorites { get; set; }//订阅
        public int coins { get; set; }//硬币
        public int play_count { get; set; }
        public int danmaku_count { get; set; }
        public int is_finish { get; set; }//是否完结
        public string newest_ep_index { get; set; }//最新话
        public string staff { get; set; }
        public string cover { get; set; }
        private SolidColorBrush _color;
        public SolidColorBrush color
        {
            get {return _color ; }
            set { _color = value; RaisePropertyChanged("color"); }
        }

        public DateTime? pub_time {
            get;
            set;
        }

        public object user_season { get; set; }
        public int attention { get; set; }//是否关注
                                          // public double last_ep_index { get; set; }//看到

        public int Num { get; set; }
        public object tags { get; set; }
        public string index { get; set; }
        public int tag_id { get; set; }
        public string tag_name { get; set; }

        public object actor { get; set; }
        public string role { get; set; }

        public object episodes { get; set; }
        public string av_id { get; set; }
        public int danmaku { get; set; }
        public string index_title { get; set; }
        public bool inLocal { get; set; }


        public int total_count { get; set; }
        public string status
        {
            get
            {
                if (is_finish == 1)
                {
                    return string.Format("已完结，共{0}话", total_count);
                }
                else
                {
                    return string.Format("连载中，更新至{0}话", newest_ep_index) ?? "";
                }
            }
        }

        public string upTime
        {
            get
            {
                if (pub_time.HasValue)
                {
                    
                    return pub_time.Value.Date.ToString("d");
                }
                else
                {
                    return "";
                }
            }

        }

        public string PlayCount
        {
            get
            {
                if (play_count > 10000)
                {
                    return ((double)play_count / 10000).ToString("0.0" + "万");
                }
                else
                {
                    return play_count.ToString();
                }
            }
        }

        public string favoritesCount
        {
            get
            {
                if (favorites > 10000)
                {
                    return ((double)favorites / 10000).ToString("0.0" + "万");
                }
                else
                {
                    return favorites.ToString();
                }
            }
        }

        public object rank { get; set; }
        public object list { get; set; }
        public object seasons { get; set; }
        public string bangumi_id { get; set; }
        public string season_id { get; set; }
        //public string title { get; set; }
        public int total_bp_count { get; set; }
        public int week_bp_count { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string Name)
        {
            if (PropertyChanged!=null)
            {
                PropertyChanged(this,new PropertyChangedEventArgs(Name));
            }
        }
    }
    //番剧Tag
    public class BanSeasonTagModel
    {
        public int count { get; set; }
        public int pages { get; set; }
        public object result { get; set; }

        public string bangumi_title { get; set; }//标题
        public string brief { get; set; }//简介
        public string pub_time { get; set; }//时间
        public string title { get; set; }
        public string Time
        {
            get
            {
                try
                {
                    return String.Format("{0}年{1}月", DateTime.Parse(pub_time).Year, DateTime.Parse(pub_time).Month);
                }
                catch (Exception)
                {
                    return "";
                }
                //string a = pub_time.Remove(11, pub_time.Length - 1);
            }
        }
        public string squareCover { get; set; }//封面
        public string season_id { get; set; }//SID
        public int is_finish { get; set; }//是否完结
        public string newest_ep_index { get; set; }//最新话
        public string Is_finish
        {
            get
            {
                if (is_finish == 1)
                {
                    return String.Format("已完结,共{0}话", newest_ep_index);
                }
                else
                {
                    return String.Format("更新至{0}话", newest_ep_index);
                }
            }
        }
        public int favorites { get; set; }//订阅数
        public string Favorites
        {
            get
            {
                return String.Format("{0}万人订阅", (double)favorites / 10000);
            }
        }
    }

    public class BannumiIndexModel
    {
        public object result { get; set; }
        //最近更新
        public object latestUpdate { get; set; }
        public object list { get; set; }
        public string title { get; set; }
        public int watchingCount { get; set; }
        public string newest_ep_index { get; set; }
        public string cover { get; set; }
        public string newest_ep_id { get; set; }
        public string season_id { get; set; }
        //分类
        public object categories { get; set; }
        public object category { get; set; }
        public string bangumi_title { get; set; }
        public int spid { get; set; }
        public string bangumi_id { get; set; }
        public string total_count { get; set; }

        //分类推荐信息
        public object recommendCategory { get; set; }
        public string tag_name { get; set; }
        public string tag_id { get; set; }
    }

    //番剧Banner
    public class BanBannerModel
    {
        public int code { get; set; }
        public string message { get; set; }
        public object result { get; set; }
        public object banners { get; set; }
        public string img { get; set; }
        public string title { get; set; }
        public string link { get; set; }
    }

    public class BanTJModel
    {
        public int code { get; set; }
        public string message { get; set; }
        public object result { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string cover { get; set; }
        public string desc { get; set; }
        public string link { get; set; }
        public string cursor { get; set; }//以防万一数字太大，用string
    }

    public class FavboxModel
    {
        public object data { get; set; }

        public int code { get; set; }

        public string fid { get; set; }
        public string mid { get; set; }
        public string name { get; set; }
        public int max_count { get; set; }//总数
        public int cur_count { get; set; }//现存

        public string Count
        {
            get
            {
                return cur_count + "/" + max_count;
            }
        }
    }

    public class SVideoModel
    {
        //第一层
        public int code { get; set; }
        public int page { get; set; }//页数
        public int numResults { get; set; }//结果数量
        public int numPages { get; set; }//结果
        public object result { get; set; }//结果
        //第二层
        public long id { get; set; }//视频AID
        public string mid { get; set; }//用户Mid
        public string author { get; set; }//作者
        public string typename { get; set; }
        public string aid { get; set; }
        public string description { get; set; }
        public string title { get; set; }//标题
        public string pic { get; set; }//封面
        public string play { get; set; }//播放
        public string video_review { get; set; }//弹幕
        public string duration { get; set; }//时长
    }
    public class SMovieModel
    {
        //第一层
        public int code { get; set; }
        public int page { get; set; }//页数
        public int numResults { get; set; }//结果数量
        public int numPages { get; set; }//结果
        public object result { get; set; }//结果
        //第二层
        public long id { get; set; }//视频AID
        public string mid { get; set; }//用户Mid
        public string author { get; set; }//作者
        public string type { get; set; }
        public string aid { get; set; }
        public string description { get; set; }
        public string title { get; set; }//标题
        public string cover { get; set; }//封面
        public string actors { get; set; }
        public string staff { get; set; }
        public string Staff
        {
            get {
                return staff.Replace("\r\n", " ").Replace("\n"," ");
            } }
        public string area { get; set; }
        public int status { get; set; }
        public string length { get; set; }
        public Visibility vis
        {
            get
            {
                if (status==2)
                {
                    return Visibility.Collapsed;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
        }
    }
    public class SUpModel
    {
        //第一层
        public int code { get; set; }
        public int page { get; set; }//页数
        public int numResults { get; set; }//结果数量
        public int numPages { get; set; }//结果
        public object result { get; set; }//结果
        //第二层
        public string mid { get; set; }//用户Mid
        public string uname { get; set; }//作者
        public string usign { get; set; }
        public string upic { get; set; }
    }

    public class SBanModel
    {
        //第一层
        public int code { get; set; }
        public int page { get; set; }//页数
        public int numResults { get; set; }//结果数量
        public int numPages { get; set; }//结果
        public object result { get; set; }//结果

        public string title { get; set; }
        public string season_id { get; set; }
        public string bangumi_id { get; set; }
        public string spid { get; set; }
        public string evaluate { get; set; }
        public string cover { get; set; }
        public int is_finish { get; set; }
        public string newest_ep_index { get; set; }
        public int total_count { get; set; }
    }

    public class SSpModel
    {
        //第一层
        public int code { get; set; }
        public int page { get; set; }//页数
        public int numResults { get; set; }//结果数量
        public int numPages { get; set; }
        public object result { get; set; }//结果

        //第三层
        public string id { get; set; }//id
        public string spid { get; set; }
        public string title { get; set; }
        public string description { get; set; }//标题
        public string pic { get; set; }//封面
    }

    public class VideoUriModel
    {
        public int code { get; set; }

        public string message { get; set; }

        public string format { get; set; }//视频类型

        public object durl { get; set; }//视频信息

        public string url { get; set; }//视频地址

        public object backup_url { get; set; }//视频备份地址
    }

    public class SohuModel
    {
        public int status { get; set; }
        public string statusText { get; set; }
        public SohuModel data { get; set; }
        public string url_blue { get; set; }

        public string download_url { get; set; }
        public string url_high { get; set; }
        public string url_nor { get; set; }
        public string url_original { get; set; }
        public string url_super { get; set; }
        
      public string url_high_mp4 { get; set; }
        public string url_nor_mp4 { get; set; }
        public string url_original_mp4 { get; set; }
        public string url_super_mp4 { get; set; }
    }
    public class QQModel
    {

    }

    public class HomeLiveModel
    {
        public int code { get; set; }
        public string message { get; set; }

        public object data { get; set; }
        public object banner { get; set; }
        public string title { get; set; }
        public string img { get; set; }
        public string remark { get; set; }
        public string link { get; set; }
        public object partitions { get; set; }
        public object partition { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public object lives { get; set; }
        public object owner { get; set; }
        public string face { get; set; }
        public string mid { get; set; }
        public object cover { get; set; }
        public string src { get; set; }
        //public string title { get; set; }
        public long online { get; set; }
        public string room_id { get; set; }
    }

    public class MessageModel
    {
        public int code { get; set; }
        public object data { get; set; }
        public string message { get; set; }

        public int reply_me { get; set; }
        public int praise_me { get; set; }
        public int notify_me { get; set; }
        public int at_me { get; set; }
        public int chat_me { get; set; }
    }
    public class MessageReplyModel
    {
        public int code { get; set; }
        public object data { get; set; }
        public string message { get; set; }
        public string id { get; set; }
        public string cursor { get; set; }

        public string title { get; set; }

        public string Title
        {
            get {
                //#{【4月】迷家 04【独家正版】}{"http://www.bilibili.com/video/av4439268/"}评论中回复了你
                Match ban = Regex.Match(title, @"#{(.*?)}{""(.*?)""}");
                if (ban.Groups[1].Value.Length == 0)
                {
                    return title;
                }
                else
                {
                    string a = ban.Groups[1].Value + title.Replace(ban.Groups[0].Value, string.Empty);
                    link = ban.Groups[2].Value;
                    return a;
                }

            }
        }
        public string link { get; set; }
        public string content { get; set; }
        public string Content {
            get
            {
                string ban = Regex.Match(content, @"^#{(.*?)}{""(.*?)""}$").Groups[1].Value;
                if (ban.Length == 0)
                {
                    return content;
                }
                else
                {
                    if (link==null)
                    {
                        link = Regex.Match(content, @"^#{(.*?)}{""(.*?)""}$").Groups[2].Value;
                    }
                    
                    return ban;
                }
            }

        }
        public string Content_Notiy
        {
            get
            {
                Match ban = Regex.Match(content, @"#{(.*?)}{""(.*?)""}");
                if (ban.Groups[1].Value.Length == 0)
                {
                    return content;
                }
                else
                {
                    string a = content.Replace(ban.Groups[0].Value, ban.Groups[1].Value);
                    link = ban.Groups[2].Value;
                    return a;
                }
            }
        }
        public object publisher { get; set; }
        public string name { get; set; }
        public string face { get; set; }
        public string mid { get; set; }
        public string time_at { get; set; }
    }
    public class MessageChatModel
    {
        public int code { get; set; }
        public object data { get; set; }
        public string message { get; set; }

        public string rid { get; set; }
        public string room_name { get; set; }
        public string avatar_url { get; set; }
        public int msg_count { get; set; }
        public string last_msg { get; set; }
        public long last_time { get; set; }

        public string Last_time {
            get {
                DateTime dtStart = new DateTime(1970, 1, 1);
                long lTime = long.Parse(last_time + "0000");
                //long lTime = long.Parse(textBox1.Text);
                TimeSpan toNow = new TimeSpan(lTime);
                DateTime dt = dtStart.Add(toNow).ToLocalTime();
                TimeSpan span = DateTime.Now - dt;
                if (span.TotalDays > 7)
                {
                    return dt.ToString("MM-dd");
                }
                else
                if (span.TotalDays > 1)
                {
                    return string.Format("{0}天前", (int)Math.Floor(span.TotalDays));
                }
                else
                if (span.TotalHours > 1)
                {
                    return string.Format("{0}小时前", (int)Math.Floor(span.TotalHours));
                }
                else
                if (span.TotalMinutes > 1)
                {
                    return string.Format("{0}分钟前", (int)Math.Floor(span.TotalMinutes));
                }
                else
                if (span.TotalSeconds >= 1)
                {
                    return string.Format("{0}秒前", (int)Math.Floor(span.TotalSeconds));
                }
                else
                {
                    return "1秒前";
                }

            } }
    }

    //直播信息
    public class LiveInfoModel
    {
        public int code { get; set; }
        public string message { get; set; }

        public object data { get; set; }
        public string room_id { get; set; }
        public string title { get; set; }

        public string mid { get; set; }
        public string uname { get; set; }
        public string face { get; set; }
        public int background_id { get; set; }//？？不明
        public long online { get; set; }
        public string start { get; set; }
        public string create_at { get; set; }
        public string status { get; set; }//LIVE or 
        public int is_attention { get; set; }//0-false,1-true

        public object meta { get; set; }
        public List<string> tag { get; set; }
        public string description { get; set; }//Html格式
        public int typeid { get; set; }
        public string cover { get; set; }
        public string check_status { get; set; }//VERIFY

        public string prepare { get; set; }

        public object roomgifts { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string price { get; set; }
        public object coin_type { get; set; }
        public string gold { get; set; }
        public string silver { get; set; }
        public string img{ get; set; }

        public string Price
        {
            get
            {
                if (silver==null|| silver==string.Empty)
                {
                    return "金瓜子:"+price;
                }
                else
                {
                    return "银瓜子:" + price;
                }
            }
        }
    }


    public class LiveRankModel
    {
        public int code { get; set; }
        public string message { get; set; }
        public object data { get; set; }
        public object list { get; set; }
        public string uid { get; set; }
        public string uname { get; set; }
        public string coin { get; set; }
        public int rank { get; set; }
        public string medal_name { get; set; }//前缀
        public int level { get; set; }
        public string color { get; set; }
        public SolidColorBrush PColor
        { get;set;}
        //用于颜色
        public SolidColorBrush DColor
        {
            get
            {
                try
                {
                    color = Convert.ToInt32(color).ToString("X2");
                    if (color.StartsWith("#"))
                        color = color.Replace("#", string.Empty);
                    int v = int.Parse(color, System.Globalization.NumberStyles.HexNumber);
                    SolidColorBrush solid = new SolidColorBrush(new Color()
                    {
                        A = Convert.ToByte(125),
                        R = Convert.ToByte((v >> 16) & 255),
                        G = Convert.ToByte((v >> 8) & 255),
                        B = Convert.ToByte((v >> 0) & 255)
                    });
                    return solid;
                }
                catch (Exception)
                {
                    SolidColorBrush solid = new SolidColorBrush(new Color()
                    {
                        A = 125,
                        R = 255,
                        G = 255,
                        B = 255
                    });
                    return solid;
                }

            }
        }

    }

    public class SearchLiveModel
    {
        public int code { get; set; }
        public string message { get; set; }

        public object data { get; set; }
        public int page { get; set; }
        public int pagesize { get; set; }

        public object room { get; set; }
        public object list { get; set; }
        public string roomid { get; set; }
        public string cover { get; set; }
        public string title { get; set; }
        public string name { get; set; }
        public string face { get; set; }
        public int online { get; set; }
        public int total_room { get; set; }
        public int total_page { get; set; }

        public object user { get; set; }
        public int live_status { get; set; }//0False,1True
        public string areaName { get; set; }
        public int fansNum { get; set; }
        public int total_user { get; set; }

        public string Live_Status
        {
            get {
                if (live_status == 1)
                {
                    return "直播中";
                }
                else
                {
                    return "闲置中";
                }
            }
        }
        public SolidColorBrush color
        {
            get
            {
                if (live_status==0)
                {
                    return new SolidColorBrush(Colors.Gray);
                }
                else
                {
                    return new SolidColorBrush(Colors.OrangeRed);
                }
            }
        }



    }
   
}
