import { SvgImage } from "../svg/svgImage";
import { Settings } from "../settings";
import { TargetType } from "./TargetType";

export abstract class aTarget {
    caliber: number;

    constructor(caliber: number) {
        this.caliber = caliber;
        this.textAngles = [];
    }

    svgImage: SvgImage;

    textAngles: number[];

    abstract getTargetType(): TargetType

    getName(): string {
        return TargetType[this.getTargetType()];
    }

    abstract getProjectileCaliber(): number;

    abstract getSize(): number;

    abstract getRings(): number[];

    abstract getOutterRing(): number;

    abstract getOutterRadius(): number;

    abstract get10Radius(): number;

    abstract getInnerTenRadius(): number;

    abstract getBlackRings(): number;

    abstract getBlackDiameter(): number;

    abstract isSolidInner(): boolean;

    abstract getRingTextCutoff(): number;

    abstract getTextOffset(diff: number, ring: number): number;

    abstract getTextRotation(): number;

    abstract getFirstRing(): number;

    abstract getFontSize(diff: number): number;

    abstract drawNorthText(): boolean;

    abstract drawSouthText(): boolean;

    abstract drawWestText(): boolean;

    abstract drawEastText(): boolean;

    public getScore(radius : number) : number {
        return 11 - (radius / this.get10Radius());
    }


    //abstract  getZoomFactor(zoomValue: number): number;

    //abstract getTrkZoomMinimum(): number;

    //abstract  getTrkZoomMaximum(): number;

    //abstract  getTrkZoomValue(): number;


    //abstract getPDFZoomFactor(List<Shot> shotList);

    //abstract (decimal, decimal) rapidFireBarDimensions();


    paintTarget(): string {
        const solidInner: boolean = this.isSolidInner();
        const blackRingCutoff: number = this.getBlackRings();
        const rings: number[] = this.getRings();

        if (this.drawEastText()) {
            this.textAngles.push(0);
        }
        if (this.drawNorthText()) {
            this.textAngles.push(Math.PI / 2.0);
        }

        if (this.drawWestText()) {
            this.textAngles.push(Math.PI);
        }

        if (this.drawSouthText()) {
            this.textAngles.push(3.0 * Math.PI / 2.0);
        }

        let width: number;
        let center: number;

        const settings: Settings = new Settings();

        // size is milimeters. 1mm = 10px
        width = this.getSize() * 10.0;
        center = width / 2;

        let svgImage = new SvgImage(width, width);
        svgImage.textFont = settings.svgImageTextFont;
        svgImage.addRectangle(0, 0, width, width, settings.svgImageBackgroundColor);

        let r = this.getFirstRing();
        for (let i = 0; i < rings.length; i++) {
            let stroke: string;
            let fill: string;

            let blackDiameter = this.getBlackDiameter();

            if (i > 0) {
                if (rings[i - 1] > blackDiameter) {
                    if (rings[i] < blackDiameter) {
                        svgImage.addCircle(center, center, blackDiameter * 10.0 / 2.0, settings.svgImageForegroundColor);
                    }
                }
            }

            let circle = rings[i];
            if (circle > blackDiameter) {
                fill = settings.svgImageBackgroundColor;
                stroke = settings.svgImageForegroundColor;
            }
            else {
                fill = settings.svgImageForegroundColor;
                stroke = settings.svgImageBackgroundColor;
            }

            let radius = circle / 2.0;
            svgImage.addCircle(center, center, radius * 10, fill, stroke, 2);

            if (r <= this.getRingTextCutoff()) {
                let txt = r.toString();



                if (r <= 10) {
                    if (i + 1 == rings.length) {
                        //center 10 ring with no inner X
                        //    float fontSize = getFontSize(0);
                        //    Font f = new Font("Arial", fontSize);
                        //    it.TranslateTransform(dimension / 2, dimension / 2); //set coordinates in the middle of the target
                        //    it.RotateTransform(getTextRotation());
                        //    it.DrawString(txt, f, bText, 0, 0, format);
                        //    it.ResetTransform();
                    }
                    else {
                        const nextCircle : number = rings[i + 1];
                        const diff : number = circle - nextCircle;
                        const fontSize : number = this.getFontSize(diff) * 18;
                        const blackRadius : number = this.getBlackDiameter() * 10.0/ 2.0;

                        this.textAngles.forEach(angle => {
                            const deltaR : number = ((radius - diff/4.5) * 10)
                            const deltaX : number =  Math.cos(angle) * deltaR - fontSize / 4.0;
                            const deltaY : number =  Math.sin(angle) * deltaR + fontSize / 2.5;
                            fill = (deltaR > blackRadius) ? settings.svgImageForegroundColor : settings.svgImageBackgroundColor;
                            svgImage.addText(center + deltaX , center + deltaY, txt, fontSize, fill, "bold");
                        })
                    }
                }
                else {
                    //r = 11
                    // txt = "X";
                    // float fontSize = getFontSize(0);
                    // Font f = new Font("Arial", fontSize);
                    // it.TranslateTransform(dimension / 2, dimension / 2); //set coordinates in the middle of the target
                    // it.RotateTransform(getTextRotation());
                    // it.DrawString(txt, f, bText, 0, 0, format);
                    // it.ResetTransform();
                }
            }
            r++;
        }
        return svgImage.toString();
    }
}