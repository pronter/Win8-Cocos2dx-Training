#include "cocos2d.h"

USING_NS_CC;

class PushBoxScene :public Layer
{
public:
	PushBoxScene();
	~PushBoxScene();

	CREATE_FUNC(PushBoxScene);

	virtual bool init();
	//void update(float delta);

	void initTouchEvent();

	void initDatabase();

	void onRightPressed(Ref* sender);
	void onLeftPressed(Ref* sender);
	void onUpPressed(Ref* sender);
	void onDownPressed(Ref* sender);

	void parseTMX(TMXTiledMap* map);

public:

	void moveTo(Sprite* sprite,int x,int y);
	Vec2 getPos(Sprite* sprite);
	bool haveBox(Vec2 pos);
	void moveBox(Vec2 nextPos,Vec2 nextBoxPos);
	bool canGo(Vec2 pos);
	bool isEnd();
	void showWin();
	static Scene* createScene();
private:
	Sprite* player;
	Sprite* movingBox;
	Vector<Sprite*> boxes;
	Vector<Sprite*> goals;
	Vector<Sprite*> walls;
private:
	Size visibleSize;

	int DIS_X, DIS_Y;

private:
	Label* scoreLabel;
	int score;
};
