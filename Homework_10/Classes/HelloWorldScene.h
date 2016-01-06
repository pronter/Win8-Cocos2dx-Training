#ifndef __HELLOWORLD_SCENE_H__
#define __HELLOWORLD_SCENE_H__

#include "cocos2d.h"
#include <string>
using namespace std;
USING_NS_CC;

class HelloWorld : public cocos2d::Layer
{
public:
    static cocos2d::Scene* createScene();
    virtual bool init();
    CREATE_FUNC(HelloWorld);

	
	virtual bool onTouchBegan(Touch *touch, Event *unused_event);
	virtual void zdcallback(Object* pSender, float h);
	virtual void sencecallback(Object* psSender);
private:
	Sprite* fish;
	Sprite* zd;
	
};

#endif
