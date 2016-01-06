#include "Game.h"
#include "Win.h"
#include <iostream>
#include <stdlib.h>
#include <sstream>
#include <string>
#include "Fail.h"
#include "SimpleAudioEngine.h"
USING_NS_CC;
using namespace std;
using namespace CocosDenshion;
using namespace cocos2d;
Scene* Game::createScene()
{
  // 'scene' is an autorelease object
  auto scene = Scene::create();

  // 'layer' is an autorelease object
  auto layer = Game::create();

  // add layer as a child to scene
  scene->addChild(layer);

  // return the scene
  return scene;
}

// on "init" you need to initialize your instance
bool Game::init()
{
  //////////////////////////////
  // 1. super init first
  if (!Layer::init())
  {
    return false;
  }

  SimpleAudioEngine::getInstance()->playBackgroundMusic("game.wav",true);
   visibleSize = Director::getInstance()->getVisibleSize();

  //主页背景
  if (visibleSize.height > visibleSize.width)
  {
    background = Sprite::create("gamebg1.jpg");
    background1 = Sprite::create("gamebg1.jpg");
  }
  else {
    background = Sprite::create("gamebg.jpg");
    background1 = Sprite::create("gamebg.jpg");
  }
  background->setPosition(Point(visibleSize.width / 2, visibleSize.height / 2));
  background1->setPosition(Point(visibleSize.width / 2, -background1->getContentSize().height / 2));
  this->addChild(background, 0);
  this->addChild(background1, 0);

   newBulletTime = 0.1;
   newEnemyTime = 0.4;
   bulletSpeed = 0.003;
   enemySpeed = 0.015;

  score = 0;
  scorelabel = LabelTTF::create("0", "Arial", 30);
  scorelabel->setPosition(Point(35, visibleSize.height * 9 / 10));
  this->addChild(scorelabel, 2);

  energy = 100;
  energylabel = LabelTTF::create("100", "Arial", 30);
  energylabel->setPosition(Point(visibleSize.width - 30, visibleSize.height * 9 / 10));
  this->addChild(energylabel, 2);

  this->plane = Sprite::create("plane.png");
  this->planeWidth = plane->getContentSize().width;
  this->planeHeight = plane->getContentSize().height;
  plane->setPosition(visibleSize.width / 2, planeHeight / 2 + 5);
  plane->setName("plane");
  this->addChild(plane, 1);
  auto listner = EventListenerTouchOneByOne::create();
  listner->onTouchBegan = CC_CALLBACK_2(Game::onTouchBegan,this);//触摸开始
  listner->onTouchMoved = CC_CALLBACK_2(Game::onTouchMoved,this);//触摸过程
  listner->onTouchEnded = CC_CALLBACK_2(Game::onTouchEnded,this);//触摸结束
  _eventDispatcher->addEventListenerWithSceneGraphPriority(listner, this);
  //每隔newBulletTime时间，执行一次shooting函数
  this->schedule(schedule_selector(Game::shooting), newBulletTime);
  this->schedule(schedule_selector(Game::newEnemy), newEnemyTime);
  this->schedule(schedule_selector(Game::bulletMoving),bulletSpeed);
  this->schedule(schedule_selector(Game::enemysMoving), enemySpeed);
  this->schedule(schedule_selector(Game::backgroundMoving), 0.08);
  this->schedule(schedule_selector(Game::collisionDetecting), 0.000001);
  return true;
}

void Game::restartSchedule(){
  this->unschedule(schedule_selector(Game::shooting));
  this->unschedule(schedule_selector(Game::newEnemy));
  this->unschedule(schedule_selector(Game::bulletMoving));
  this->unschedule(schedule_selector(Game::enemysMoving));

  //this->resumeSchedulerAndActions();
  this->schedule(schedule_selector(Game::shooting), newBulletTime);
  this->schedule(schedule_selector(Game::newEnemy), newEnemyTime);
  this->schedule(schedule_selector(Game::bulletMoving), bulletSpeed);
  this->schedule(schedule_selector(Game::enemysMoving), enemySpeed);
}
void Game::ContrlSpeed(float t){
  if (score >= 1000 && score < 2000){
    newBulletTime = 0.2;
    newEnemyTime = 0.3;
    bulletSpeed = 0.02;
    enemySpeed = 0.03;
    restartSchedule();
  }
  if (score >= 2000 && score < 3000){
    newBulletTime = 0.1;
    newEnemyTime = 0.2;
    bulletSpeed = 0.02;
    enemySpeed = 0.025;
    restartSchedule();
  }
  if (score >= 3000 && score < 4000){
    newBulletTime = 0.08;
    newEnemyTime = 0.1;
    bulletSpeed = 0.015;
    enemySpeed = 0.02;
    restartSchedule();
  }
  if (score >= 4000 && score < 5000){
    newBulletTime = 0.08;
    newEnemyTime = 0.1;
    bulletSpeed = 0.01;
    enemySpeed = 0.015;
    restartSchedule();
  }

}
void Game::WinGame(){
  Win::score = score;
  auto* win = Win::createScene();
  Director::getInstance()->replaceScene(win);
}
void Game::GameOver(){
  Fail::myscore = score;
  auto fail = Fail::createScene();

  Director::getInstance()->replaceScene(fail);
}
void Game::collisionDetecting(float t){
  if (score > 5000){
    WinGame();
  }
  Rect pr(plane->getPositionX(),plane->getPositionY(),planeWidth,planeHeight);
  for (int j = 0; j < enemys.size(); j++){
    auto enemy = enemys.at(j);//敌机
    Rect er(enemy->getPositionX(), enemy->getPositionY(), 
      enemy->getContentSize().width, enemy->getContentSize().height);//获取敌机位置范围
    for (int i = 0; i < bullets.size(); i++){
      auto bullet = bullets.at(i);//子弹
      Rect br(bullet->getPositionX(), bullet->getPositionY(), 
        bullet->getContentSize().width, bullet->getContentSize().height);//获取子弹位置范围
      if (br.intersectsRect(er)){//判断子弹位置范围(br)与敌机位置范围(er)是否有交集
        auto ps = ParticleSystemQuad::create("explo.plist");//粒子效果使用
        ps->setPosition(Point(bullet->getPositionX(), bullet->getPositionY()));
        this->addChild(ps);
        SimpleAudioEngine::getInstance()->playEffect("bomb.wav");
        score += enemy->getTag();
        enemy->removeFromParent();
        enemys.eraseObject(enemy);
        bullet->removeFromParent();
        bullets.eraseObject(bullet);
        stringstream ss;
        ss << score;
        scorelabel->setString(ss.str());
        j--;
        break;
      }
    }
    if (er.intersectsRect(pr)){
      energy -= (enemy->getTag() * 1.5);
      SimpleAudioEngine::getInstance()->playEffect("demaged.wav");
      enemy->removeFromParent();
      enemys.eraseObject(enemy);
      stringstream ss;
      ss << energy;
      energylabel->setString(ss.str());
      if (energy <= 0){
        GameOver();
      }
      j--;
      break;
    }
  }
}
void Game::newEnemy(float t){
  int count = score / 1000 + 1;
  count = count > 3 ? 3 : count;
  for (int k = 0; k < count; k++){
    int type = rand() % 3;
    int pos_x = rand() % (int)visibleSize.width;
    pos_x = pos_x < 32 ? pos_x + visibleSize.width / 2 : pos_x;
    pos_x = pos_x >= visibleSize.width - 32 ? pos_x - visibleSize.width / 2 : pos_x;
    if (type == 0){
      auto enemy = Sprite::create("enemy1.png");
      enemy->setTag(20);
      enemy->setPosition(Point(pos_x, visibleSize.height - 35));
      this->addChild(enemy, 1);
      enemys.pushBack(enemy);
    }
    else{
      auto enemy = Sprite::create("enemy2.png");
      enemy->setTag(10);
      enemy->setPosition(Point(pos_x, visibleSize.height - 35));
      this->addChild(enemy, 1);
      enemys.pushBack(enemy);
    }
  }
}
void Game::enemysMoving(float t){
  int s = enemys.size();
  int step = score / 1000 + 2;
  for (int i = 0; i < enemys.size(); i++)
  {
    auto enemy = enemys.at(i);
    if (enemy->getPositionY() <= 0){
      SimpleAudioEngine::getInstance()->playEffect("jianxiao.wav");
      energy -= (enemy->getTag() / 10);
      stringstream ss;
      ss << energy;
      energylabel->setString(ss.str());
      if (energy <= 0){
        GameOver();
      }
      enemy->removeFromParent();
      enemys.eraseObject(enemy);
      i--;
    }
    else 
      enemy->setPosition(enemy->getPosition().x, enemy->getPosition().y - step);
  }
}
void Game::backgroundMoving(float t){
  int bh = background->getPosition().y;
  int bh1 = background1->getPosition().y;
  bh += 4;
  bh1 += 4;
  if (bh >= background->getContentSize().height){
    background->setPosition(Point(visibleSize.width / 2, visibleSize.height / 2));
    background1->setPosition(Point(visibleSize.width / 2, -background1->getContentSize().height / 2));
  }
  else{
    background->setPosition(Point(background->getPosition().x, bh));
    background1->setPosition(Point(background1->getPosition().x, bh1));
  }
}

void Game::backgroundChange(float t){
  auto temvs = Director::getInstance()->getVisibleSize();

  //主页背景
  if (temvs.height != visibleSize.height && temvs.width != visibleSize.width)
  {
    background->removeFromParentAndCleanup(false);
    if (temvs.height > temvs.width)
       background = Sprite::create("gamebg1.jpg");
    else
      background = Sprite::create("gamebg.jpg");
    visibleSize = Director::getInstance()->getVisibleSize();
    background->setPosition(Point(temvs.width / 2, temvs.height / 2));
    this->addChild(background, 0);
  }
}

void Game::bulletMoving(float t){
  int step = score / 1000 + 2;
  for (int i = 0; i < bullets.size(); i++){
    auto bullet = bullets.at(i);
    if (bullet->getPositionY() >= visibleSize.height)
    {
      bullet->removeFromParentAndCleanup(true);
      bullets.eraseObject(bullet);
      i--;
    }
    else
      bullet->setPosition(Point(bullet->getPosition().x, bullet->getPosition().y + step));
  }
}
void Game::shooting(float t){
  int count = score / 1000 + 1;
  count = count > 3 ? 3 : count;
  for (int i = 0; i < count; i++){
    auto newbullet = Sprite::create("bullet.png");
    newbullet->setPosition(Point(plane->getPosition().x, plane->getPosition().y + plane->getContentSize().height / 2 - 5));
    this->addChild(newbullet, 1);
    bullets.pushBack(newbullet);
  }
}

bool Game::onTouchBegan(Touch *touch, Event *unused_event){
  return true;
}
void Game::onTouchMoved(Touch *touch, Event *unused_event){
  int x = touch->getLocation().x;
  if (x < planeWidth / 2)
    x = planeWidth / 2;
  if (x > visibleSize.width - planeWidth / 2)
    x = visibleSize.width - planeWidth / 2;
  //战机移动
  plane->setPosition(Point(x, plane->getPosition().y));
}

void Game::onTouchEnded(Touch *touch, Event *unused_event){}



void Game::menuCallback(Ref* sender){
}
void Game::menuCloseCallback(Ref* pSender)
{
#if (CC_TARGET_PLATFORM == CC_PLATFORM_WP8) || (CC_TARGET_PLATFORM == CC_PLATFORM_WINRT)
  MessageBox("You pressed the close button. Windows Store Apps do not implement a close button.", "Alert");
  return;
#endif

  Director::getInstance()->end();

#if (CC_TARGET_PLATFORM == CC_PLATFORM_IOS)
  exit(0);
#endif
}
