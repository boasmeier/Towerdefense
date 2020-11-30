using System;

internal interface IShootController
{
    SOTower Tower { get; }

    // should be fired, if shot is fired
    event Action HandleShoot;

    // timer has expired since last shot
    bool TimerExpired();

    // instantiate and direct a shot
    void Shoot();

    //if new wave is spawned, start shooting
    void StartShooting(int w);

    //if wave ended, stop shooting
    void StopShooting(int wOld, int wNew);
}