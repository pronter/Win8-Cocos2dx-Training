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
  //����¼���Ӧ
  bool onTouchBegan(Touch *touch, Event *unused_event);
  void onTouchMoved(Touch *touch, Event *unused_event);
  void onTouchEnded(Touch *touch, Event *unused_event);
  void backgroundChange(float t);
  //�����ӵ�
  void shooting(float t);
  //�����ӵ��ƶ�
  void bulletMoving(float t);
  //�����ƶ�
  void backgroundMoving(float t);
  //�л��ƶ�
  void enemysMoving(float t);
  //�²���һ���л�
  void newEnemy(float t);
  //�����ӵ����л������ֺ��ƶ��ٶ�
  void ContrlSpeed(float t);
  //����
  void GameOver();
  //��ȡʤ��
  void WinGame();
  //�������мƻ�����
  void restartSchedule();
  //��ײ���
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
