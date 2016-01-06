#include "HelloWorldScene.h"
#include "Game.h"
#include "Win.h"
#include "Help.h"
#include "SimpleAudioEngine.h"
USING_NS_CC;
using namespace cocos2d;
using namespace CocosDenshion;
Scene* HelloWorld::createScene()
{
  auto* win = Win::createScene();
  Director::getInstance()->replaceScene(win);
    // 'scene' is an autorelease object
    auto scene = Scene::create();
    
    // 'layer' is an autorelease object
    auto layer = HelloWorld::create();

    // add layer as a child to scene
    scene->addChild(layer);

    // return the scene
    return scene;
}

// on "init" you need to initialize your instance
bool HelloWorld::init()
{
    //////////////////////////////
    // 1. super init first
    if ( !Layer::init() )
    {
        return false;
    }
    SimpleAudioEngine::getInstance()->stopAllEffects();
    SimpleAudioEngine::getInstance()->preloadBackgroundMusic("hanshengsui.wav");
    SimpleAudioEngine::getInstance()->preloadBackgroundMusic("game.wav");
    SimpleAudioEngine::getInstance()->preloadEffect("bomb.wav");
    SimpleAudioEngine::getInstance()->preloadEffect("demaged.wav");
    SimpleAudioEngine::getInstance()->preloadEffect("jianxiao.wav");
    SimpleAudioEngine::getInstance()->preloadEffect("shibai.wav");
    SimpleAudioEngine::getInstance()->preloadEffect("success.wav");
    SimpleAudioEngine::getInstance()->playBackgroundMusic("hanshengsui.wav",true);
    Size visibleSize = Director::getInstance()->getVisibleSize();
    //Ö÷Ò³±³¾°
    auto sprite = Sprite::create("startbg.jpg");
    sprite->setPosition(Vec2(visibleSize.width/2, visibleSize.height/2));
    this->addChild(sprite, 0);

    //²Ëµ¥
    auto start = MenuItemImage::create("start.png", "start.png", CC_CALLBACK_1(HelloWorld::menuCallback,this));
    auto help = MenuItemImage::create("help.png", "help.png", CC_CALLBACK_1(HelloWorld::menuCallback, this));
    auto exit = MenuItemImage::create("exit.png", "exit.png", CC_CALLBACK_1(HelloWorld::menuCallback, this));
    start->setTag(101);
    start->setPosition(Point(visibleSize.width / 2,visibleSize.height * 3 /4 ));
    help->setTag(102);
    help->setPosition(Point(visibleSize.width / 2, visibleSize.height * 3/4 - 130));
    exit->setTag(103);
    exit->setPosition(Point(visibleSize.width / 2, visibleSize.height *3/4 - 250));
    auto menu = Menu::create(start,help,exit,NULL);
    menu->setPosition(Point::ZERO);
    this->addChild(menu, 0);

    return true;
}

void HelloWorld::menuCallback(Ref* sender){
  auto director = Director::getInstance();
  auto item = (MenuItemImage*)sender;
  switch (item->getTag()){
  case 101:
    director->replaceScene(Game::createScene());
    break;
  case 102:
    director->replaceScene(Help::createScene());
    break;
  case 103:
    menuCloseCallback(sender);
    break;
  }
}
void HelloWorld::menuCloseCallback(Ref* pSender)
{
  auto exitlayer = Sprite::create("popup.png");
  exitlayer->setName("exitlayer");
  auto vs = Director::getInstance()->getVisibleSize();
  exitlayer->setPosition(Point(vs.width / 2, vs.height / 2 + 30));
  auto sure = Sprite::create("sure.png");
  auto cancel = Sprite::create("cancel.png");
  sure->setPosition(vs.width / 2 - 140, vs.height / 2 - 125);
  cancel->setPosition(vs.width / 2 + 140, vs.height / 2 - 125);
  cancel->setName("cancel");
  sure->setName("sure");
  this->addChild(exitlayer, 1);
  this->addChild(sure, 1);
  this->addChild(cancel, 1);
  auto listner = EventListenerTouchOneByOne::create();
  listner->onTouchBegan = CC_CALLBACK_2(HelloWorld::touchBegan, this);
  listner->onTouchMoved = CC_CALLBACK_2(HelloWorld::touchMoved, this);
  listner->onTouchEnded = CC_CALLBACK_2(HelloWorld::touchEnded, this);
  _eventDispatcher->addEventListenerWithSceneGraphPriority(listner, sure);
  _eventDispatcher->addEventListenerWithSceneGraphPriority(listner->clone(), cancel);
}

bool HelloWorld::touchBegan(Touch* touch, Event* event_){
  log("here------------------------------------");
  auto exitlayer = this->getChildByName("exitlayer");
  auto sure = this->getChildByName("sure");
  auto cancel = this->getChildByName("cancel");
  auto psure = sure->getPosition();
  auto pcancel = cancel->getPosition();
  auto suresize = sure->getContentSize();
  auto cancelsize = cancel->getContentSize();
  Point loc(touch->getLocation());
  Rect rectsrue = Rect(psure.x - suresize.width / 2, psure.y - suresize.height / 2,
    suresize.width, suresize.height);
  Rect rectcancel = Rect(pcancel.x - cancelsize.width / 2, pcancel.y - cancelsize.height / 2,
    cancelsize.width, cancelsize.height);
  if (rectsrue.containsPoint(loc)){
    Director::getInstance()->end();
    exit(0);
    return true;
  }
  if (rectcancel.containsPoint(loc)){
    sure->removeFromParentAndCleanup(false);
    cancel->removeFromParentAndCleanup(false);
    exitlayer->removeFromParentAndCleanup(false);
    return true;
  }
  return true;
}
void HelloWorld::touchMoved(Touch* touch, Event* event_){}

void HelloWorld::touchEnded(Touch* touch, Event* event_){}
