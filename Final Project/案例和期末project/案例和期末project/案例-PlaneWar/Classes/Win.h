#ifndef __WIN_H__
#define __WIN_H__
#include "network/HttpClient.h"
#include <iostream>
#include <string>
#include "cocos2d.h"
using namespace cocos2d;
using namespace std;
using namespace cocos2d::network;

class Win : public cocos2d::Layer
{
public:
  // there's no 'id' in cpp, so we recommend returning the class instance pointer
  static cocos2d::Scene* createScene();

  // Here's a difference. Method 'init' in cocos2d-x returns bool, instead of returning 'id' in cocos2d-iphone
  virtual bool init();

  // a selector callback
  void menuCloseCallback(cocos2d::Ref* pSender);

  void menuCallback(cocos2d::Ref* pSender);
  //��������Ӧ��ɺ�Ĳ�������
  void onHttpRequestCompleted(HttpClient *sender, HttpResponse *response);
  //������post��������
  void postData();
  //�ӷ�������get���а�
  void getRank();
  CREATE_FUNC(Win);

  int type = 0;
  //���а����
  vector<string> scores;
  //���˷���
  static int score;

};

#endif // __HELLOWORLD_SCENE_H__
