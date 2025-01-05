import { Shot } from './Shot';
import { TargetType } from '../targets/TargetType';

export class ShotResult {
    shotList: Shot[];
    targetType: TargetType;
    shooterName: string;

    constructor() {
        this.shotList = [];
    }
}