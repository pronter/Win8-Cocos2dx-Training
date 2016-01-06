#ifndef __Fail_H__
#define __Fail_H__

#include "cocos2d.h"
#include<vector>
#include "network/HttpClient.h"
#include <iostream>
#include <string>
using namespace std;
using namespace cocos2d;
using namespace cocos2d::network;
class Fail : public cocos2d::Layer
{
public:
  CREATE_FUNC(Fail);
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
  //���˷���
  static int myscore;
  //���а����
  vector<string> scores;
  int type = 0;
};
#endif // __HELLOWORLD_SCENE_H__
