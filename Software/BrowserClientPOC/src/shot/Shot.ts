import { aTarget } from '../targets/aTarget';
import { TargetType } from '../targets/TargetType';
import { AirRifle } from '../targets/AirRifle';


export class Shot{
    x: number;
    y: number;
    radius?: number;
    angle?: number;
    score?: number;
    decimalScore?: number;
    innerTen?: boolean;

    public computeScore(targetType: TargetType) : void {
        this.radius = Math.sqrt(this.x * this.x + this .y * this.y);
        this.angle = Math.atan2(this.y, this.x);

        let target : aTarget;

        switch(targetType) {
            case TargetType.AirRifle:
                target = new AirRifle(4.5);
                break;
        }

        let score2 : number = target.getScore(target.caliber / 2.0);
        this.decimalScore =  Math.floor(score2 * 10) / 10.0 + 0.0;

        if (this.decimalScore < 1.0) {  
            this.decimalScore = 0.0;
        }
        if (this.decimalScore > 10.9) {
            this.decimalScore = 10.9;
        }

        
        if (this.radius <= target.getInnerTenRadius()) {
            this.innerTen = true;
        } else {
            this.innerTen = false;
        }
   }
}