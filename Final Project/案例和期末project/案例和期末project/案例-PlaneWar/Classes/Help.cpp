#include <iostream>
#include <string>
#include "Help.h"
#include "HelloWorldScene.h"

USING_NS_CC;
using namespace std;
using namespace cocos2d;
Scene* Help::createScene()
{
  // 'scene' is an autorelease object
  auto scene = Scene::create();

  // 'layer' is an autorelease object
  auto layer = Help::create();

  // add layer as a child to scene
  scene->addChild(layer);


  // return the scene
  return scene;
}

// on "init" you need to initialize your instance
bool Help::init()
{
  //////////////////////////////
  // 1. super init first
  if (!Layer::init())
  {
    return false;
  }

  Size visibleSize = Director::getInstance()->getVisibleSize();
  //��ҳ����
  auto sp = Sprite::create("helpbg.jpg");
  sp->setPosition(Point(visibleSize.width / 2, visibleSize.height / 2));
  this->addChild(sp, 0);
  //�˵�
  auto back = MenuItemImage::create("backmenu.png", "backmenu.png", CC_CALLBACK_1(Help::menuCallback, this));
  back->setPosition(100, visibleSize.height - 45);
  auto menu = Menu::create(back, NULL);
  menu->setPosition(Point::ZERO);
  this->addChild(menu);
  //string txt = "ͨ�����(����)�������ƶ�ս�������Ͻ���ʾ���������ֵл���A�л�����һ����10�֣�B�л�����һ����15�֣�����ײ��಻�������Σ����Ͻ���ʾ��ǰս������������Ϊ0ʱ��ս�������������ﵽ1000ʱ��ս��ʤ��";
  auto label = Label::createWithTTF("Attention", "fonts/Marker Felt.ttf", 30);
  label->setPosition(Point(visibleSize.width / 2, visibleSize.height / 4 * 3));
  this->addChild(label, 1);
  auto txt = Sprite::create("text.png");
  txt->setPosition(Point(visibleSize.width / 2, visibleSize.height / 4 * 3 - 150));
  this->addChild(txt, 1);
 
  return true;
}

void Help::menuCallback(Ref* sender){
  Director::getInstance()->replaceScene(HelloWorld::createScene());
}
void Help::menuCloseCallback(Ref* pSender)
{
#if (CC_TARGET_PLATFORM == CC_PLATFORM_WP8) || (CC_TARGET_PLATFORM == CC_PLATFORM_WINRT)
  //MessageBox("You pressed the close button. Windows Store Apps do not implement a close button.", "Alert");

  return;
#endif

  Director::getInstance()->end();

#if (CC_TARGET_PLATFORM == CC_PLATFORM_IOS)
  exit(0);
#endif
}
