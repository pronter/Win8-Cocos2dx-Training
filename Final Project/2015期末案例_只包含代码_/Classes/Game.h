#ifndef __GAME_SCENE_H__
#define __GAME_SCENE_H__

#include "cocos2d.h"
using namespace cocos2d;
class Game : public cocos2d::Layer
{
public:
  // there's no 'id' in cpp, so we recommend returning the class instance pointer
  static cocos2d::Scene* createScene();

  // Here's a difference. Method 'init' in cocos2d-x returns bool, instead of returning 'id' in cocos2d-iphone
  virtual bool init();

  // a selector callback
  void menuCloseCallback(cocos2d::Ref* pSender);

  void menuCallback(Ref* sender);
  //鼠标事件响应
  bool onTouchBegan(Touch *touch, Event *unused_event);
  void onTouchMoved(Touch *touch, Event *unused_event);
  void onTouchEnded(Touch *touch, Event *unused_event);
  void backgroundChange(float t);
  //发射子弹
  void shooting(float t);
  //控制子弹移动
  void bulletMoving(float t);
  //背景移动
  void backgroundMoving(float t);
  //敌机移动
  void enemysMoving(float t);
  //新产生一个敌机
  void newEnemy(float t);
  //控制子弹，敌机，出现和移动速度
  void ContrlSpeed(float t);
  //死亡
  void GameOver();
  //获取胜利
  void WinGame();
  //重启所有计划任务
  void restartSchedule();
  //碰撞检测
  void collisionDetecting(float t);
  CREATE_FUNC(Game);
private:
  float newBulletTime;
  float newEnemyTime;
  float bulletSpeed;
  float enemySpeed;
  int planeWidth = 0;
  int planeHeight = 0;
  Sprite* plane = NULL;
  Sprite* background = NULL;
  Sprite* background1 = NULL;
  Vector<Sprite*> bullets;
  Vector<Sprite*> enemys;
  Size visibleSize;
  LabelTTF* scorelabel;
  LabelTTF* energylabel;
  int score;
  int energy;
};

#endif // __HELLOWORLD_SCENE_H__
