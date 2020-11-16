internal interface IShootController
{
    SOTower Tower { get; }

    // timer has expired since last shot
    bool TimerExpired();

    // instantiate and direct a shot
    void Shoot();

    //if new wave is spawned, start shooting
    void StartShooting(int w);

    //if wave ended, stop shooting
    void StopShooting(int wOld, int wNew);
}