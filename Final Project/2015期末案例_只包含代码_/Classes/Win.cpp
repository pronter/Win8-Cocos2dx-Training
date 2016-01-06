#include "Win.h"
#include "HelloWorldScene.h"
#include "SimpleAudioEngine.h"
#include "tinyxml2/tinyxml2.h"
#include <stdlib.h>
#include <vector>
using namespace tinyxml2;
using namespace cocos2d::network;
USING_NS_CC;
using namespace std;
using namespace CocosDenshion;
Scene* Win::createScene()
{
  // 'scene' is an autorelease object
  auto scene = Scene::create();

  // 'layer' is an autorelease object
  auto layer = Win::create();

  // add layer as a child to scene
  scene->addChild(layer);

  // return the scene
  return scene;
}
int Win::score = 0;
// on "init" you need to initialize your instance
bool Win::init()
{
  //////////////////////////////
  // 1. super init first
  if (!Layer::init())
  {
    return false;
  }
  SimpleAudioEngine::getInstance()->stopAllEffects();
  SimpleAudioEngine::getInstance()->playBackgroundMusic("hanshengsui.wav", true);
  SimpleAudioEngine::getInstance()->playEffect("success.wav",true);
  Size visibleSize = Director::getInstance()->getVisibleSize();
  auto sp = Sprite::create("winfail.jpg");
  sp->setPosition(visibleSize.width / 2, visibleSize.height / 2);
  this->addChild(sp);
  auto winpicture = Sprite::create("win.png");
  winpicture->setPosition(visibleSize.width / 2, visibleSize.height * 3 / 4);
  this->addChild(winpicture);
  auto rank = MenuItemImage::create("rank.png", "rank.png", CC_CALLBACK_1(Win::menuCallback, this));
  auto startmenu = MenuItemImage::create("menu.png", "menu.png", CC_CALLBACK_1(Win::menuCallback, this));
  auto menu = Menu::create(startmenu, rank, NULL);
  startmenu->setTag(108);
  startmenu->setPosition(visibleSize.width / 2, visibleSize.height / 2);
  rank->setPosition(visibleSize.width / 2, visibleSize.height / 2  - 150);
  menu->setPosition(Point::ZERO);
  this->addChild(menu, 0);
  postData();
  getRank();
  return true;
}
void Win::menuCallback(cocos2d::Ref* pSender){
  auto item = (MenuItemImage*)pSender;
  if (item->getTag() == 108){
    Director::getInstance()->replaceScene(HelloWorld::createScene());
  }
  else{
    //ȥ��Fail8.1,�������磬�鿴���а�
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
      //0.5������ת�Ƕ�1800��
      auto act = RotateBy::create(0.5, 1800);
      //rankboard��Sprite��act->reverse()ָ������
      rankboard->runAction(Sequence::create(act, act->reverse(), NULL));
    }
    stringstream srs;
    srs << score;
    auto lab = LabelTTF::create(srs.str(), "Arial", 24);
    lab->setPosition(Point(190, 38));
    lab->setColor(ccc3(255, 0, 255));
    rankboard->addChild(lab);

  }
}


void Win::menuCloseCallback(Ref* pSender)
{
}

void Win::getRank(){
  HttpRequest* request = new HttpRequest();
  request->setUrl("http://172.18.187.83:8888/rank/getScore/?id=404&num=10");
  request->setRequestType(HttpRequest::Type::GET);
  request->setResponseCallback(CC_CALLBACK_2(Win::onHttpRequestCompleted, this));
  request->setTag("GET test");
  cocos2d::network::HttpClient::getInstance()->send(request);
  request->release();
}
void Win::postData(){
  HttpRequest* request = new HttpRequest();//��������
  request->setUrl("http://172.18.187.83:8888/rank/newScore/");//����URL
  request->setRequestType(HttpRequest::Type::POST);//ѡ��post��ʽ��������
  stringstream sts;
  sts << score;
  //ch������ı���������ֵ,idָ��ϷID��key:��ϷKEY,(����Ҫ��ͬѧ������TA������ϷID��KEY�������һҳPPT)
  string ch = "id=404&user=mvp&score=" + sts.str() + "&words=aaaa&key=f213503c49194e46378da174b765b598";
  const char* postData = ch.c_str();
  request->setRequestData(postData, strlen(postData));//������������
  request->setTag("POST test");
  cocos2d::network::HttpClient::getInstance()->send(request);//��������
  request->release();//�ͷ�����
}
void Win::onHttpRequestCompleted(HttpClient *sender, HttpResponse *response)
{
  if (!response)
  {
    return;
  }
  if (0 != strlen(response->getHttpRequest()->getTag()))
  {
    log("%s completed", response->getHttpRequest()->getTag());
  }
  int statusCode = response->getResponseCode();
  char statusString[64] = {};
  if (!response->isSucceed())
  {
    log("response failed");
    log("error buffer: %s", response->getErrorBuffer());
    return;
  }
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