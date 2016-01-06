#include "cocos2d.h"

USING_NS_CC;

class PushBoxScene :public Layer
{
public:
	PushBoxScene();
	~PushBoxScene();

	CREATE_FUNC(PushBoxScene);

	virtual bool init();


	void initTouchEvent();



	void onRightPressed(Ref* sender);
	void onLeftPressed(Ref* sender);
	void onUpPressed(Ref* sender);
	void onDownPressed(Ref* sender);

private:
	Size visibleSize;

};
