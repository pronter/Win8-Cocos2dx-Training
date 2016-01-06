#include "Fail.h"
#include <sstream>
#include "HelloWorldScene.h"
#include "SimpleAudioEngine.h"
USING_NS_CC;
using namespace CocosDenshion;

Scene* Fail::createScene()
{
  // 'scene' is an autorelease object
  auto scene = Scene::create();

  // 'layer' is an autorelease object
  auto layer = Fail::create();

  // add layer as a child to scene
  scene->addChild(layer);

  // return the scene
  return scene;
}
int Fail::myscore = 0;
bool Fail::init()
{
  if (!Layer::init())
  {
    return false;
  }

  SimpleAudioEngine::getInstance()->playBackgroundMusic("hanshengsui.wav", true);
  SimpleAudioEngine::getInstance()->stopAllEffects();
  SimpleAudioEngine::getInstance()->playEffect("shibai.wav",true);
  Size visibleSize = Director::getInstance()->getVisibleSize();
  auto sp = Sprite::create("winfail.jpg");
  sp->setPosition(visibleSize.width / 2, visibleSize.height / 2);
  this->addChild(sp);
  auto Failpicture = Sprite::create("fail.png");
  Failpicture->setPosition(visibleSize.width / 2, visibleSize.height * 3 / 4);
  this->addChild(Failpicture);
  auto rank = MenuItemImage::create("rank.png", "rank.png", CC_CALLBACK_1(Fail::menuCallback, this));
  auto startmenu = MenuItemImage::create("menu.png", "menu.png", CC_CALLBACK_1(Fail::menuCallback, this));
  auto menu = Menu::create(startmenu, rank, NULL);
  startmenu->setTag(108);
  startmenu->setPosition(visibleSize.width / 2, visibleSize.height / 2);
  rank->setPosition(visibleSize.width / 2, visibleSize.height / 2 - 150);
  menu->setPosition(Point::ZERO);
  this->addChild(menu, 0);
  postData();
  getRank();
  return true;
}
void Fail::menuCallback(cocos2d::Ref* pSender){
  auto item = (MenuItemImage*)pSender;
  if (item->getTag() == 108){
    Director::getInstance()->replaceScene(HelloWorld::createScene());
  }
  else{
    //去到Fail8.1,访问网络，查看排行榜
    this->removeChildByTag(10001);
    auto rankboard = Sprite::create("rankboard.png");
    rankboard->setPosition(Point(1150, 500));
    rankboard->setTag(10001);
    this->addChild(rankboard, 2);
    for (int i = 0; i < 10; i++){
      string sstr = "";
      if (i >= scores.size())
      {
        sstr = "0";
      }
      else
        sstr = scores[i];
      auto lab = LabelTTF::create(sstr, "Arial", 20);
      Color3B co = ccc3(255, 0, 0);
      lab->setColor(co);
      lab->setPosition(Point(180, 378 - i * 33));
      rankboard->addChild(lab);
      auto actionby1 = SkewBy::create(0.3, 90.0f, -90.0f);
      auto actionby2 = SkewBy::create(0.3, 45.0f, 90.0f);
      rankboard->runAction(Sequence::create(actionby2,actionby2->reverse(),actionby1,actionby1->reverse(), NULL));
    }
    stringstream srs;
    srs << myscore;
    auto lab = LabelTTF::create(srs.str(), "Arial", 24);
    lab->setPosition(Point(190, 38));
    lab->setColor(ccc3(255, 0, 255));
    rankboard->addChild(lab);

  }
}

void Fail::getRank(){
  HttpRequest* request = new HttpRequest();//创建请求
  request->setUrl("http://172.18.187.83:8888/rank/getScore/?id=404&num=10");//设置URL,注意参数
  request->setRequestType(HttpRequest::Type::GET);//设置请求方式为GET
  //设置服务器响应完毕后的回调函数
  request->setResponseCallback(CC_CALLBACK_2(Fail::onHttpRequestCompleted, this));
  request->setTag("GET test");
  cocos2d::network::HttpClient::getInstance()->send(request);//发送请求
  request->release();//释放请求
}
void Fail::postData(){
  HttpRequest* request = new HttpRequest();
  request->setUrl("http://172.18.187.83:8888/rank/newScore/");
  request->setRequestType(HttpRequest::Type::POST);
  stringstream sts;
  sts << myscore;
  string ch = "id=404&user=mvp&score=" + sts.str() + "&words=aaaa&key=f213503c49194e46378da174b765b598";
  const char* postData = ch.c_str();
  request->setRequestData(postData, strlen(postData));
  request->setTag("POST test");
  cocos2d::network::HttpClient::getInstance()->send(request);
  request->release();
}
void Fail::onHttpRequestCompleted(HttpClient *sender, HttpResponse *response)
{
  if (!response)
  {
    return;
  }
  if (0 != strlen(response->getHttpRequest()->getTag()))//获取请求Tag
  {
    log("%s completed", response->getHttpRequest()->getTag());
  }
  int statusCode = response->getResponseCode();//获取状态码
  char statusString[64] = {};
  if (!response->isSucceed())
  {
    log("response failed");
    log("error buffer: %s", response->getErrorBuffer());//获取错误信息
    return;
  }
  //获取请求的响应数据（即用户需要的数据），数据放在了vector<char>里面
  std::vector<char> *buffer = response->getResponseData();
  char* s = new char[(*buffer).size()];
  for (unsigned int i = 0; i < buffer->size(); i++)
  {
    printf("%c", (*buffer)[i]);
    s[i] = (*buffer)[i];
  }
  string str(s);
  for (int i = 0; i < str.length() - 7; i++)
  {
    string s = str.substr(i, 7);
    if (s == "<score>"){
      i = i + 7;
      string ds = "";
      while (true){
        string ss = str.substr(i, 8);
        if (ss == "</score>")
        {
          break;
        }
        ds += str[i];
        i++;
      }
      scores.push_back(ds);
    }
  }
  
}



void Fail::menuCloseCallback(Ref* pSender)
{
}
