#ifndef __HELLOWORLD_SCENE_H__
#define __HELLOWORLD_SCENE_H__

#include "cocos2d.h"
using namespace cocos2d;
class HelloWorld : public cocos2d::Layer
{
public:
    //������
    static cocos2d::Scene* createScene();

    //��ʼ���˵�ҳ
    virtual bool init();
    
    // �˳���ť�ص�����
    void menuCloseCallback(cocos2d::Ref* pSender);

    //�˵���ť�ص�����
    void menuCallback(Ref* sender);


    //������ʼ
    bool touchBegan(Touch* touch, Event* event_);
    //�������� 
    void touchMoved(Touch* touch, Event* event_);
    //��������
    void touchEnded(Touch* touch, Event* event_);

    // implement the "static create()" method manually
    CREATE_FUNC(HelloWorld);
};

#endif // __HELLOWORLD_SCENE_H__
