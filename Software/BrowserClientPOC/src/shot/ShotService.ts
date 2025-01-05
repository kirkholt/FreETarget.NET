import { TargetType } from '../targets/TargetType';
import { Shot } from './Shot';
import {ShotResult} from './ShotResult';

export class Shotservice { 
    public shotResult?: ShotResult;
    private storageKey: string = 'shotResult';

    
    createNewShotResult(targetType: TargetType, shooterName: string   ) : void {
        let shotResult = new ShotResult();
        shotResult.targetType = targetType;
        shotResult.shooterName = shooterName;
        this.shotResult = shotResult;
        console.log('createNewShotResult: ' + JSON.stringify(this.shotResult));
    }

    saveShotResult() : boolean {
        let result = false;
        if (this.shotResult) {
            const serializedShotResultt = JSON.stringify(this.shotResult);
            localStorage.setItem(this.storageKey, serializedShotResultt);
            console.log('saveShotResult: ' + serializedShotResultt);
            result = true;
        }
        return result;
    }

    loadShotResult() : boolean {
        let result = false;
        const serializedShotResult = localStorage.getItem(this.storageKey);
        if (serializedShotResult) {
            this.shotResult = JSON.parse(serializedShotResult);
            console.log('loadShotResult: ' + JSON.stringify(this.shotResult));
            result = true;
        }       
        return result;
    }

    createRandomShot(maxxy: number) : Shot {
        let shot = new Shot();
        shot.x = 2.0 * Math.random() * maxxy - maxxy; // random number between -maxxy and maxxy
        shot.y = 2.0 * Math.random() * maxxy - maxxy; // random number between -maxxy and maxxy
        console.log('createRandomShot: ' + JSON.stringify(shot));
        return shot;
    }

    addShotToShotResult(shot: Shot) : boolean {
        let result = false;
        if (!this.shotResult) {
            shot.computeScore(this.shotResult.targetType);
            this.shotResult.shotList.push(shot);
            console.log('addShotToShotResult: ' + JSON.stringify(shot));
            result = true;
        }
        return result;
    }
}
